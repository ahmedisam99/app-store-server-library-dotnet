using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body for turning off automatic renewal of a subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptioncancelrequest"/>
public sealed class AdvancedCommerceSubscriptionCancelRequest : AdvancedCommerceRequest
{
    /// <summary>
    /// The App Store storefront of the subscription.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }
}
