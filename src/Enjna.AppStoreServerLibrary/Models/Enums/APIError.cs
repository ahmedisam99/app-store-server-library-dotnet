namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// Error codes that App Store Server API responses return.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/error_codes"/>
public enum APIError
{
    /// <summary>
    /// An error that indicates an invalid request.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/generalbadrequesterror"/>
    GeneralBadRequest = 4000000,

    /// <summary>
    /// An error that indicates an invalid app identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidappidentifiererror"/>
    InvalidAppIdentifier = 4000002,

    /// <summary>
    /// An error that indicates an invalid request revision.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidrequestrevisionerror"/>
    InvalidRequestRevision = 4000005,

    /// <summary>
    /// An error that indicates an invalid transaction identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidtransactioniderror"/>
    InvalidTransactionId = 4000006,

    /// <summary>
    /// An error that indicates an invalid original transaction identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidoriginaltransactioniderror"/>
    InvalidOriginalTransactionId = 4000008,

    /// <summary>
    /// An error that indicates an invalid extend-by-days value.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidextendbydayserror"/>
    InvalidExtendByDays = 4000009,

    /// <summary>
    /// An error that indicates an invalid reason code.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidextendreasoncodeerror"/>
    InvalidExtendReasonCode = 4000010,

    /// <summary>
    /// An error that indicates an invalid request identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidrequestidentifiererror"/>
    InvalidRequestIdentifier = 4000011,

    /// <summary>
    /// An error that indicates that the start date is earlier than the earliest allowed date.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/startdatetoofarinpasterror"/>
    StartDateTooFarInPast = 4000012,

    /// <summary>
    /// An error that indicates that the end date precedes the start date, or the two dates are equal.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/startdateafterenddateerror"/>
    StartDateAfterEndDate = 4000013,

    /// <summary>
    /// An error that indicates the pagination token is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidpaginationtokenerror"/>
    InvalidPaginationToken = 4000014,

    /// <summary>
    /// An error that indicates the start date is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidstartdateerror"/>
    InvalidStartDate = 4000015,

    /// <summary>
    /// An error that indicates the end date is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidenddateerror"/>
    InvalidEndDate = 4000016,

    /// <summary>
    /// An error that indicates the pagination token expired.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/paginationtokenexpirederror"/>
    PaginationTokenExpired = 4000017,

    /// <summary>
    /// An error that indicates the notification type or subtype is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidnotificationtypeerror"/>
    InvalidNotificationType = 4000018,

    /// <summary>
    /// An error that indicates the request is invalid because it has too many constraints applied.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/multiplefilterssuppliederror"/>
    MultipleFiltersSupplied = 4000019,

    /// <summary>
    /// An error that indicates the test notification token is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidtestnotificationtokenerror"/>
    InvalidTestNotificationToken = 4000020,

    /// <summary>
    /// An error that indicates an invalid sort parameter.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidsorterror"/>
    InvalidSort = 4000021,

    /// <summary>
    /// An error that indicates an invalid product type parameter.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidproducttypeerror"/>
    InvalidProductType = 4000022,

    /// <summary>
    /// An error that indicates the product ID parameter is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidproductiderror"/>
    InvalidProductId = 4000023,

    /// <summary>
    /// An error that indicates an invalid subscription group identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidsubscriptiongroupidentifiererror"/>
    InvalidSubscriptionGroupIdentifier = 4000024,

    /// <summary>
    /// An error that indicates the query parameter exclude-revoked is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidexcluderevokederror"/>
    [System.Obsolete]
    InvalidExcludeRevoked = 4000025,

    /// <summary>
    /// An error that indicates an invalid in-app ownership type parameter.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidinappownershiptypeerror"/>
    InvalidInAppOwnershipType = 4000026,

    /// <summary>
    /// An error that indicates a required storefront country code is empty.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidemptystorefrontcountrycodelisterror"/>
    InvalidEmptyStorefrontCountryCodeList = 4000027,

    /// <summary>
    /// An error that indicates a storefront code is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidstorefrontcountrycodeerror"/>
    InvalidStorefrontCountryCode = 4000028,

    /// <summary>
    /// An error that indicates the revoked parameter contains an invalid value.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidrevokederror"/>
    InvalidRevoked = 4000030,

    /// <summary>
    /// An error that indicates the status parameter is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidstatuserror"/>
    InvalidStatus = 4000031,

    /// <summary>
    /// An error that indicates the value of the account tenure field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidaccounttenureerror"/>
    InvalidAccountTenure = 4000032,

    /// <summary>
    /// An error that indicates the value of the app account token field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidappaccounttokenerror"/>
    InvalidAppAccountToken = 4000033,

    /// <summary>
    /// An error that indicates the value of the consumption status field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidconsumptionstatuserror"/>
    InvalidConsumptionStatus = 4000034,

    /// <summary>
    /// An error that indicates the customer consented field is invalid or doesn't indicate that the customer consented.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidcustomerconsentederror"/>
    InvalidCustomerConsented = 4000035,

    /// <summary>
    /// An error that indicates the value in the delivery status field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invaliddeliverystatuserror"/>
    InvalidDeliveryStatus = 4000036,

    /// <summary>
    /// An error that indicates the value in the lifetime dollars purchased field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidlifetimedollarspurchasederror"/>
    InvalidLifetimeDollarsPurchased = 4000037,

    /// <summary>
    /// An error that indicates the value in the lifetime dollars refunded field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidlifetimedollarsrefundederror"/>
    InvalidLifetimeDollarsRefunded = 4000038,

    /// <summary>
    /// An error that indicates the value in the platform field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidplatformerror"/>
    InvalidPlatform = 4000039,

    /// <summary>
    /// An error that indicates the value in the playtime field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidplaytimeerror"/>
    InvalidPlayTime = 4000040,

    /// <summary>
    /// An error that indicates the value in the sample content provided field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidsamplecontentprovidederror"/>
    InvalidSampleContentProvided = 4000041,

    /// <summary>
    /// An error that indicates the value in the user status field is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invaliduserstatuserror"/>
    InvalidUserStatus = 4000042,

    /// <summary>
    /// An error that indicates the transaction identifier doesn't represent a consumable in-app purchase.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidtransactionnotconsumableerror"/>
    [System.Obsolete]
    InvalidTransactionNotConsumable = 4000043,

    /// <summary>
    /// An error that indicates the transaction identifier represents an unsupported in-app purchase type.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidtransactiontypenotsupportederror"/>
    InvalidTransactionTypeNotSupported = 4000047,

    /// <summary>
    /// An error that indicates the endpoint doesn't support an app transaction ID.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/apptransactionidnotsupportederror"/>
    AppTransactionIdNotSupported = 4000048,

    /// <summary>
    /// An error that indicates the image that's uploading is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/invalidimageerror"/>
    InvalidImage = 4000161,

    /// <summary>
    /// An error that indicates the header text is too long.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/headertoolongerror"/>
    HeaderTooLong = 4000162,

    /// <summary>
    /// An error that indicates the body text is too long.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/bodytoolongerror"/>
    BodyTooLong = 4000163,

    /// <summary>
    /// An error that indicates the locale is invalid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/invalidlocaleerror"/>
    InvalidLocale = 4000164,

    /// <summary>
    /// An error that indicates the alternative text for an image is too long.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/alttexttoolongerror"/>
    AltTextTooLong = 4000175,

    /// <summary>
    /// An error that indicates the app account token value is not a valid UUID.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/invalidappaccounttokenuuiderror"/>
    InvalidAppAccountTokenUuid = 4000183,

    /// <summary>
    /// An error that indicates the transaction is for a product the customer obtains through Family Sharing, which the endpoint doesn't support.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/familytransactionnotsupportederror"/>
    FamilyTransactionNotSupported = 4000185,

    /// <summary>
    /// An error that indicates the endpoint expects an original transaction identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/transactionidisnotoriginaltransactioniderror"/>
    TransactionIdIsNotOriginalTransactionId = 4000187,

    /// <summary>
    /// An error that indicates the subscription doesn't qualify for a renewal-date extension due to its subscription state.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/subscriptionextensionineligibleerror"/>
    SubscriptionExtensionIneligible = 4030004,

    /// <summary>
    /// An error that indicates the subscription doesn't qualify for a renewal-date extension because it has already received the maximum extensions.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/subscriptionmaxextensionerror"/>
    SubscriptionMaxExtension = 4030005,

    /// <summary>
    /// An error that indicates a subscription isn't directly eligible for a renewal date extension because the user obtained it through Family Sharing.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/familysharedsubscriptionextensionineligibleerror"/>
    FamilySharedSubscriptionExtensionIneligible = 4030007,

    /// <summary>
    /// An error that indicates when you reach the maximum number of uploaded images.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/maximumnumberofimagesreachederror"/>
    MaximumNumberOfImagesReached = 4030014,

    /// <summary>
    /// An error that indicates when you reach the maximum number of uploaded messages.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/maximumnumberofmessagesreachederror"/>
    MaximumNumberOfMessagesReached = 4030016,

    /// <summary>
    /// An error that indicates the message isn't in the approved state, so you can't configure it as a default message.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messagenotapprovederror"/>
    MessageNotApproved = 4030017,

    /// <summary>
    /// An error that indicates the image isn't in the approved state, so you can't configure it as part of a default message.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imagenotapprovederror"/>
    ImageNotApproved = 4030018,

    /// <summary>
    /// An error that indicates the image is currently in use as part of a message, so you can't delete it.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imageinuseerror"/>
    ImageInUse = 4030019,

    /// <summary>
    /// An error that indicates the App Store account wasn't found.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/accountnotfounderror"/>
    AccountNotFound = 4040001,

    /// <summary>
    /// An error response that indicates the App Store account wasn't found, but you can try again.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/accountnotfoundretryableerror"/>
    AccountNotFoundRetryable = 4040002,

    /// <summary>
    /// An error that indicates the app wasn't found.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/appnotfounderror"/>
    AppNotFound = 4040003,

    /// <summary>
    /// An error response that indicates the app wasn't found, but you can try again.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/appnotfoundretryableerror"/>
    AppNotFoundRetryable = 4040004,

    /// <summary>
    /// An error that indicates an original transaction identifier wasn't found.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/originaltransactionidnotfounderror"/>
    OriginalTransactionIdNotFound = 4040005,

    /// <summary>
    /// An error response that indicates the original transaction identifier wasn't found, but you can try again.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/originaltransactionidnotfoundretryableerror"/>
    OriginalTransactionIdNotFoundRetryable = 4040006,

    /// <summary>
    /// An error that indicates that the App Store server couldn't find a notifications URL for your app in this environment.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/servernotificationurlnotfounderror"/>
    ServerNotificationUrlNotFound = 4040007,

    /// <summary>
    /// An error that indicates that the test notification token is expired or the test notification status isn't available.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/testnotificationnotfounderror"/>
    TestNotificationNotFound = 4040008,

    /// <summary>
    /// An error that indicates the server didn't find a subscription-renewal-date extension request for the request identifier and product identifier you provided.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/statusrequestnotfounderror"/>
    StatusRequestNotFound = 4040009,

    /// <summary>
    /// An error that indicates a transaction identifier wasn't found.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/transactionidnotfounderror"/>
    TransactionIdNotFound = 4040010,

    /// <summary>
    /// An error that indicates the system can't find the image identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imagenotfounderror"/>
    ImageNotFound = 4040014,

    /// <summary>
    /// An error that indicates the system can't find the message identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messagenotfounderror"/>
    MessageNotFound = 4040015,

    /// <summary>
    /// An error response that indicates an app transaction doesn't exist for the specified customer.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/apptransactiondoesnotexisterror"/>
    AppTransactionDoesNotExist = 4040019,

    /// <summary>
    /// An error that indicates the image identifier already exists.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imagealreadyexistserror"/>
    ImageAlreadyExists = 4090000,

    /// <summary>
    /// An error that indicates the message identifier already exists.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messagealreadyexistserror"/>
    MessageAlreadyExists = 4090001,

    /// <summary>
    /// An error that indicates that the request exceeded the rate limit.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/ratelimitexceedederror"/>
    RateLimitExceeded = 4290000,

    /// <summary>
    /// An error that indicates a general internal error.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/generalinternalerror"/>
    GeneralInternal = 5000000,

    /// <summary>
    /// An error response that indicates an unknown error occurred, but you can try again.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/generalinternalretryableerror"/>
    GeneralInternalRetryable = 5000001
}
