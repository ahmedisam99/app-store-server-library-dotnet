using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Enjna.AppStoreServerLibrary.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Environment = Enjna.AppStoreServerLibrary.Models.Environment;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A client for the App Store Server API.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi"/>
public class AppStoreServerAPIClient
{
    private const string ProductionUrl = "https://api.storekit.itunes.apple.com";
    private const string SandboxUrl = "https://api.storekit-sandbox.itunes.apple.com";
    private const string LocalTestingUrl = "https://local-testing-base-url";
    private const string UserAgent = "enjna-app-store-server-library/dotnet/1.0.0";
    private static readonly JsonSerializerOptions JsonOptions = new();

    private readonly string _signingKey;
    private readonly string _keyId;
    private readonly string _issuerId;
    private readonly string _bundleId;
    private readonly string _urlBase;
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Creates a new App Store Server API client.
    /// </summary>
    /// <param name="signingKey">Your private key downloaded from App Store Connect, in PEM format.</param>
    /// <param name="keyId">Your private key ID from App Store Connect.</param>
    /// <param name="issuerId">Your issuer ID from the Keys page in App Store Connect.</param>
    /// <param name="bundleId">Your app's bundle ID.</param>
    /// <param name="environment">The environment to target.</param>
    /// <param name="httpClient">An optional <see cref="HttpClient"/> instance to use for requests.</param>
    /// <exception cref="ArgumentException">Thrown when the environment is Xcode.</exception>
    public AppStoreServerAPIClient(
        string signingKey,
        string keyId,
        string issuerId,
        string bundleId,
        Environment environment,
        HttpClient? httpClient = null)
    {
        _signingKey = signingKey;
        _keyId = keyId;
        _issuerId = issuerId;
        _bundleId = bundleId;
        _httpClient = httpClient ?? new HttpClient();

        _urlBase = environment switch
        {
            Environment.Production => ProductionUrl,
            Environment.Sandbox => SandboxUrl,
            Environment.LocalTesting => LocalTestingUrl,
            Environment.Xcode => throw new ArgumentException("Xcode is not a supported for an AppStoreServerAPIClient"),
            _ => throw new ArgumentException($"Unsupported environment: {environment}")
        };
    }

    /// <summary>
    /// Uses a subscription's product identifier to extend the renewal date for all of its eligible active subscribers.
    /// </summary>
    /// <param name="request">The request body for extending a subscription renewal date for all of its active subscribers.</param>
    /// <returns>A response that indicates the server successfully received the subscription-renewal-date extension request.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/extend_subscription_renewal_dates_for_all_active_subscribers"/>
    public async Task<MassExtendRenewalDateResponse> ExtendRenewalDateForAllActiveSubscribersAsync(
        MassExtendRenewalDateRequest request)
    {
        var path = "/inApps/v1/subscriptions/extend/mass";

        return await MakeRequestAsync<MassExtendRenewalDateResponse>(path, HttpMethod.Post, null, request, true);
    }

    /// <summary>
    /// Extends the renewal date of a customer's active subscription using the original transaction identifier.
    /// </summary>
    /// <param name="originalTransactionId">The original transaction identifier of the subscription receiving a renewal date extension.</param>
    /// <param name="request">The request body containing subscription-renewal-extension data.</param>
    /// <returns>A response that indicates whether an individual renewal-date extension succeeded, and related details.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/extend_a_subscription_renewal_date"/>
    public async Task<ExtendRenewalDateResponse> ExtendSubscriptionRenewalDateAsync(
        string originalTransactionId,
        ExtendRenewalDateRequest request)
    {
        var path = $"/inApps/v1/subscriptions/extend/{originalTransactionId}";

        return await MakeRequestAsync<ExtendRenewalDateResponse>(path, HttpMethod.Put, null, request, true);
    }

    /// <summary>
    /// Get the statuses for all of a customer's auto-renewable subscriptions in your app.
    /// </summary>
    /// <param name="transactionId">The identifier of a transaction that belongs to the customer, and which may be an original transaction identifier.</param>
    /// <param name="status">An optional filter that indicates the status of subscriptions to include in the response. Your query may specify more than one status query parameter.</param>
    /// <returns>A response that contains status information for all of a customer's auto-renewable subscriptions in your app.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get_all_subscription_statuses"/>
    public async Task<StatusResponse> GetAllSubscriptionStatusesAsync(
        string transactionId,
        Status[]? status = null)
    {
        var queryParams = new Dictionary<string, string[]>();
        if (status is not null)
        {
            queryParams["status"] = status.Select(s => ((int)s).ToString()).ToArray();
        }

        var path = $"/inApps/v1/subscriptions/{transactionId}";

        return await MakeRequestAsync<StatusResponse>(path, HttpMethod.Get, queryParams, null, true);
    }

    /// <summary>
    /// Get a paginated list of all of a customer's refunded in-app purchases for your app.
    /// </summary>
    /// <param name="transactionId">The identifier of a transaction that belongs to the customer, and which may be an original transaction identifier.</param>
    /// <param name="revision">A token you provide to get the next set of up to 20 transactions. All responses include a revision token. Use the revision token from the previous <see cref="RefundHistoryResponse"/>.</param>
    /// <returns>A response that contains status information for all of a customer's auto-renewable subscriptions in your app.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get_refund_history"/>
    public async Task<RefundHistoryResponse> GetRefundHistoryAsync(
        string transactionId,
        string? revision = null)
    {
        var queryParams = new Dictionary<string, string[]>();
        if (revision is not null)
        {
            queryParams["revision"] = [revision];
        }

        var path = $"/inApps/v2/refund/lookup/{transactionId}";

        return await MakeRequestAsync<RefundHistoryResponse>(path, HttpMethod.Get, queryParams, null, true);
    }

    /// <summary>
    /// Checks whether a renewal date extension request completed, and provides the final count of successful or failed extensions.
    /// </summary>
    /// <param name="requestIdentifier">The UUID that represents your request to the Extend Subscription Renewal Dates for All Active Subscribers endpoint.</param>
    /// <param name="productId">The product identifier of the auto-renewable subscription that you request a renewal-date extension for.</param>
    /// <returns>A response that indicates the current status of a request to extend the subscription renewal date to all eligible subscribers.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get_status_of_subscription_renewal_date_extensions"/>
    public async Task<MassExtendRenewalDateStatusResponse> GetStatusOfSubscriptionRenewalDateExtensionsAsync(
        string requestIdentifier,
        string productId)
    {
        var path = $"/inApps/v1/subscriptions/extend/mass/{productId}/{requestIdentifier}";

        return await MakeRequestAsync<MassExtendRenewalDateStatusResponse>(path, HttpMethod.Get, null, null, true);
    }

    /// <summary>
    /// Check the status of the test App Store server notification sent to your server.
    /// </summary>
    /// <param name="testNotificationToken">The test notification token received from the Request a Test Notification endpoint.</param>
    /// <returns>A response that contains the contents of the test notification sent by the App Store server and the result from your server.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get_test_notification_status"/>
    public async Task<CheckTestNotificationResponse> GetTestNotificationStatusAsync(string testNotificationToken)
    {
        var path = $"/inApps/v1/notifications/test/{testNotificationToken}";

        return await MakeRequestAsync<CheckTestNotificationResponse>(path, HttpMethod.Get, null, null, true);
    }

    /// <summary>
    /// Get a list of notifications that the App Store server attempted to send to your server.
    /// </summary>
    /// <param name="paginationToken">An optional token you use to get the next set of up to 20 notification history records. All responses that have more records available include a paginationToken. Omit this parameter the first time you call this endpoint.</param>
    /// <param name="request">The request body that includes the start and end dates, and optional query constraints.</param>
    /// <returns>A response that contains the App Store Server Notifications history for your app.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get_notification_history"/>
    public async Task<NotificationHistoryResponse> GetNotificationHistoryAsync(
        string? paginationToken,
        NotificationHistoryRequest request)
    {
        var queryParams = new Dictionary<string, string[]>();
        if (paginationToken is not null)
        {
            queryParams["paginationToken"] = [paginationToken];
        }

        var path = "/inApps/v1/notifications/history";

        return await MakeRequestAsync<NotificationHistoryResponse>(path, HttpMethod.Post, queryParams, request, true);
    }

    /// <summary>
    /// Get a customer's in-app purchase transaction history for your app.
    /// </summary>
    /// <param name="transactionId">The identifier of a transaction that belongs to the customer, and which may be an original transaction identifier.</param>
    /// <param name="revision">A token you provide to get the next set of up to 20 transactions. All responses include a revision token. Note: For requests that use the revision token, include the same query parameters from the initial request. Use the revision token from the previous <see cref="HistoryResponse"/>.</param>
    /// <param name="request">The request body that includes query constraints.</param>
    /// <param name="version">The version of the Get Transaction History endpoint to use. V2 is recommended.</param>
    /// <returns>A response that contains the customer's transaction history for an app.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get_transaction_history"/>
    public async Task<HistoryResponse> GetTransactionHistoryAsync(
        string transactionId,
        string? revision,
        TransactionHistoryRequest request,
        GetTransactionHistoryVersion version = GetTransactionHistoryVersion.V2)
    {
        var queryParams = new Dictionary<string, string[]>();

        if (revision is not null)
        {
            queryParams["revision"] = [revision];
        }

        if (request.StartDate.HasValue)
        {
            queryParams["startDate"] = [request.StartDate.Value.ToString()];
        }

        if (request.EndDate.HasValue)
        {
            queryParams["endDate"] = [request.EndDate.Value.ToString()];
        }

        if (request.ProductIds is not null)
        {
            queryParams["productId"] = request.ProductIds;
        }

        if (request.ProductTypes is not null)
        {
            queryParams["productType"] = request.ProductTypes.Select(GetEnumMemberValue).ToArray();
        }

        if (request.Sort.HasValue)
        {
            queryParams["sort"] = [GetEnumMemberValue(request.Sort.Value)];
        }

        if (request.SubscriptionGroupIdentifiers is not null)
        {
            queryParams["subscriptionGroupIdentifier"] = request.SubscriptionGroupIdentifiers;
        }

        if (request.InAppOwnershipType.HasValue)
        {
            queryParams["inAppOwnershipType"] = [GetEnumMemberValue(request.InAppOwnershipType.Value)];
        }

        if (request.Revoked.HasValue)
        {
            queryParams["revoked"] = [request.Revoked.Value.ToString().ToLowerInvariant()];
        }

        var versionStr = GetEnumMemberValue(version);
        var path = $"/inApps/{versionStr}/history/{transactionId}";

        return await MakeRequestAsync<HistoryResponse>(path, HttpMethod.Get, queryParams, null, true);
    }

    /// <summary>
    /// Get information about a single transaction for your app.
    /// </summary>
    /// <param name="transactionId">The identifier of a transaction that belongs to the customer, and which may be an original transaction identifier.</param>
    /// <returns>A response that contains signed transaction information for a single transaction.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get_transaction_info"/>
    public async Task<TransactionInfoResponse> GetTransactionInfoAsync(string transactionId)
    {
        var path = $"/inApps/v1/transactions/{transactionId}";

        return await MakeRequestAsync<TransactionInfoResponse>(path, HttpMethod.Get, null, null, true);
    }

    /// <summary>
    /// Get a customer's in-app purchases from a receipt using the order ID.
    /// </summary>
    /// <param name="orderId">The order ID for in-app purchases that belong to the customer.</param>
    /// <returns>A response that includes the order lookup status and an array of signed transactions for the in-app purchases in the order.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/look_up_order_id"/>
    public async Task<OrderLookupResponse> LookUpOrderIdAsync(string orderId)
    {
        var path = $"/inApps/v1/lookup/{orderId}";

        return await MakeRequestAsync<OrderLookupResponse>(path, HttpMethod.Get, null, null, true);
    }

    /// <summary>
    /// Ask App Store Server Notifications to send a test notification to your server.
    /// </summary>
    /// <returns>A response that contains the test notification token.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/request_a_test_notification"/>
    public async Task<SendTestNotificationResponse> RequestTestNotificationAsync()
    {
        var path = "/inApps/v1/notifications/test";

        return await MakeRequestAsync<SendTestNotificationResponse>(path, HttpMethod.Post, null, null, true);
    }

    /// <summary>
    /// Send consumption information about a consumable in-app purchase to the App Store after your server receives a consumption request notification.
    /// </summary>
    /// <param name="transactionId">The transaction identifier for which you're providing consumption information. You receive this identifier in the CONSUMPTION_REQUEST notification the App Store sends to your server.</param>
    /// <param name="request">The request body containing consumption information.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/send-consumption-information-v1"/>
    [Obsolete("Use SendConsumptionInformationAsync instead.")]
    public async Task SendConsumptionDataAsync(string transactionId, ConsumptionRequestV1 request)
    {
        var path = $"/inApps/v1/transactions/consumption/{transactionId}";

        await MakeRequestAsync<object?>(path, HttpMethod.Put, null, request, false);
    }

    /// <summary>
    /// Send consumption information about an In-App Purchase to the App Store after your server receives a consumption request notification.
    /// </summary>
    /// <param name="transactionId">The transaction identifier for which you're providing consumption information. You receive this identifier in the CONSUMPTION_REQUEST notification the App Store sends to your server's App Store Server Notifications V2 endpoint.</param>
    /// <param name="request">The request body containing consumption information.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/send-consumption-information"/>
    public async Task SendConsumptionInformationAsync(string transactionId, ConsumptionRequest request)
    {
        var path = $"/inApps/v2/transactions/consumption/{transactionId}";

        await MakeRequestAsync<object?>(path, HttpMethod.Put, null, request, false);
    }

    /// <summary>
    /// Sets the app account token value for a purchase the customer makes outside your app, or updates its value in an existing transaction.
    /// </summary>
    /// <param name="originalTransactionId">The original transaction identifier of the transaction to receive the app account token update.</param>
    /// <param name="request">The request body that contains a valid app account token value.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/set-app-account-token"/>
    public async Task SetAppAccountTokenAsync(string originalTransactionId, UpdateAppAccountTokenRequest request)
    {
        var path = $"/inApps/v1/transactions/{originalTransactionId}/appAccountToken";

        await MakeRequestAsync<object?>(path, HttpMethod.Put, null, request, false);
    }

    /// <summary>
    /// Upload an image to use for retention messaging.
    /// </summary>
    /// <param name="imageIdentifier">A UUID you provide to uniquely identify the image you upload. Must be lowercase.</param>
    /// <param name="image">The image file to upload.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/upload-image"/>
    public async Task UploadImageAsync(string imageIdentifier, byte[] image)
    {
        var path = $"/inApps/v1/messaging/image/{imageIdentifier}";

        await MakeRequestAsync<object?>(path, HttpMethod.Put, null, image, false);
    }

    /// <summary>
    /// Delete a previously uploaded image.
    /// </summary>
    /// <param name="imageIdentifier">The identifier of the image to delete.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/delete-image"/>
    public async Task DeleteImageAsync(string imageIdentifier)
    {
        var path = $"/inApps/v1/messaging/image/{imageIdentifier}";

        await MakeRequestAsync<object?>(path, HttpMethod.Delete, null, null, false);
    }

    /// <summary>
    /// Get the image identifier and state for all uploaded images.
    /// </summary>
    /// <returns>A response that contains status information for all images.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/get-image-list"/>
    public async Task<GetImageListResponse> GetImageListAsync()
    {
        var path = "/inApps/v1/messaging/image/list";

        return await MakeRequestAsync<GetImageListResponse>(path, HttpMethod.Get, null, null, true);
    }

    /// <summary>
    /// Upload a message to use for retention messaging.
    /// </summary>
    /// <param name="messageIdentifier">A UUID you provide to uniquely identify the message you upload. Must be lowercase.</param>
    /// <param name="request">The message text to upload.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/upload-message"/>
    public async Task UploadMessageAsync(string messageIdentifier, UploadMessageRequestBody request)
    {
        var path = $"/inApps/v1/messaging/message/{messageIdentifier}";

        await MakeRequestAsync<object?>(path, HttpMethod.Put, null, request, false);
    }

    /// <summary>
    /// Delete a previously uploaded message.
    /// </summary>
    /// <param name="messageIdentifier">The identifier of the message to delete.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/delete-message"/>
    public async Task DeleteMessageAsync(string messageIdentifier)
    {
        var path = $"/inApps/v1/messaging/message/{messageIdentifier}";

        await MakeRequestAsync<object?>(path, HttpMethod.Delete, null, null, false);
    }

    /// <summary>
    /// Get the message identifier and state of all uploaded messages.
    /// </summary>
    /// <returns>A response that contains status information for all messages.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/get-message-list"/>
    public async Task<GetMessageListResponse> GetMessageListAsync()
    {
        var path = "/inApps/v1/messaging/message/list";

        return await MakeRequestAsync<GetMessageListResponse>(path, HttpMethod.Get, null, null, true);
    }

    /// <summary>
    /// Configure a default message for a specific product in a specific locale.
    /// </summary>
    /// <param name="productId">The product identifier for the default configuration.</param>
    /// <param name="locale">The locale for the default configuration.</param>
    /// <param name="request">The request body that includes the message identifier to configure as the default message.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/configure-default-message"/>
    public async Task ConfigureDefaultMessageAsync(
        string productId,
        string locale,
        DefaultConfigurationRequest request)
    {
        var path = $"/inApps/v1/messaging/default/{productId}/{locale}";

        await MakeRequestAsync<object?>(path, HttpMethod.Put, null, request, false);
    }

    /// <summary>
    /// Delete a default message for a product in a locale.
    /// </summary>
    /// <param name="productId">The product ID of the default message configuration.</param>
    /// <param name="locale">The locale of the default message configuration.</param>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/delete-default-message"/>
    public async Task DeleteDefaultMessageAsync(string productId, string locale)
    {
        var path = $"/inApps/v1/messaging/default/{productId}/{locale}";

        await MakeRequestAsync<object?>(path, HttpMethod.Delete, null, null, false);
    }

    /// <summary>
    /// Get a customer's app transaction information for your app.
    /// </summary>
    /// <param name="transactionId">Any originalTransactionId, transactionId or appTransactionId that belongs to the customer for your app.</param>
    /// <returns>A response that contains signed app transaction information for a customer.</returns>
    /// <exception cref="APIException">Thrown if a response was returned indicating the request could not be processed.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/get-app-transaction-info"/>
    public async Task<AppTransactionInfoResponse> GetAppTransactionInfoAsync(string transactionId)
    {
        var path = $"/inApps/v1/transactions/appTransactions/{transactionId}";

        return await MakeRequestAsync<AppTransactionInfoResponse>(path, HttpMethod.Get, null, null, true);
    }

    private async Task<T> MakeRequestAsync<T>(
        string path,
        HttpMethod method,
        Dictionary<string, string[]>? queryParameters,
        object? body,
        bool parseResponse)
    {
        var uriBuilder = new UriBuilder(_urlBase + path);

        if (queryParameters is { Count: > 0 })
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var (key, values) in queryParameters)
            {
                foreach (var value in values)
                {
                    query.Add(key, value);
                }
            }

            uriBuilder.Query = query.ToString();
        }

        using var request = new HttpRequestMessage(method, uriBuilder.Uri);
        request.Headers.TryAddWithoutValidation("User-Agent", UserAgent);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CreateBearerToken());
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (body is byte[] binaryBody)
        {
            request.Content = new ByteArrayContent(binaryBody);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
        }
        else if (body is not null)
        {
            var json = JsonSerializer.Serialize(body, JsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        using var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            if (!parseResponse)
            {
                return default!;
            }

            var responseBodyStr = await response.Content.ReadAsStringAsync();
            var responseBody = JsonSerializer.Deserialize<T>(responseBodyStr, JsonOptions);

            if (responseBody is null)
            {
                throw new Exception("Unexpected response body format");
            }

            return responseBody;
        }

        try
        {
            var errorBody = await response.Content.ReadAsStringAsync();
            var error = JsonSerializer.Deserialize<ErrorResponseBody>(errorBody, JsonOptions);

            if (error?.ErrorCode.HasValue == true)
            {
                var rawApiError = error.ErrorCode.Value;
                var apiError = Enum.IsDefined(typeof(APIError), rawApiError)
                    ? (APIError?)rawApiError
                    : null;

                throw new APIException((int)response.StatusCode, rawApiError, apiError, error.ErrorMessage);
            }

            throw new APIException((int)response.StatusCode);
        }
        catch (APIException)
        {
            throw;
        }
        catch
        {
            throw new APIException((int)response.StatusCode);
        }
    }

    private string CreateBearerToken()
    {
        var ecdsa = ECDsa.Create();
        ecdsa.ImportFromPem(_signingKey);

        var securityKey = new ECDsaSecurityKey(ecdsa)
        {
            KeyId = _keyId
        };

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _issuerId,
            Audience = "appstoreconnect-v1",
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha256),
            Claims = new Dictionary<string, object>
            {
                ["bid"] = _bundleId
            }
        };

        var handler = new JsonWebTokenHandler();
        return handler.CreateToken(descriptor);
    }

    private static string GetEnumMemberValue<TEnum>(TEnum value) where TEnum : struct, Enum
    {
        var memberInfo = typeof(TEnum).GetMember(value.ToString());
        if (memberInfo.Length > 0)
        {
            var attr = memberInfo[0].GetCustomAttribute<EnumMemberAttribute>();
            if (attr?.Value is not null)
            {
                return attr.Value;
            }
        }

        return value.ToString();
    }
}
