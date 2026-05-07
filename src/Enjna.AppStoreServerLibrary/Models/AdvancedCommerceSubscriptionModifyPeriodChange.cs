using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The data your app provides to change the period of an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmodifyperiodchange"/>
public sealed class AdvancedCommerceSubscriptionModifyPeriodChange
{
    /// <summary>
    /// When the change goes into effect.
    /// </summary>
    [JsonPropertyName("effective")]
    public required AdvancedCommerceEffective Effective { get; set; }

    /// <summary>
    /// The new subscription period.
    /// </summary>
    [JsonPropertyName("period")]
    public required AdvancedCommercePeriod Period { get; set; }
}
