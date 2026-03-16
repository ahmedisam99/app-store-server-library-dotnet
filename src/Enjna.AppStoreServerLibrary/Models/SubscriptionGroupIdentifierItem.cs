using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Information for auto-renewable subscriptions, including signed transaction information and signed renewal information, for one subscription group.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/subscriptiongroupidentifieritem"/>
public sealed class SubscriptionGroupIdentifierItem
{
    /// <summary>
    /// The identifier of the subscription group that the subscription belongs to.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/subscriptiongroupidentifier"/>
    [JsonPropertyName("subscriptionGroupIdentifier")]
    public string? SubscriptionGroupIdentifier { get; set; }

    /// <summary>
    /// An array of the most recent App Store-signed transaction information and App Store-signed renewal information for all auto-renewable subscriptions in the subscription group.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/lasttransactionsitem"/>
    [JsonPropertyName("lastTransactions")]
    public LastTransactionsItem[]? LastTransactions { get; set; }
}
