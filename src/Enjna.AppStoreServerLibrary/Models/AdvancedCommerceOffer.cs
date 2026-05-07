using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A discount offer for an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/offer"/>
public sealed class AdvancedCommerceOffer
{
    /// <summary>
    /// The period of the offer.
    /// </summary>
    [JsonPropertyName("period")]
    public AdvancedCommerceOfferPeriod? Period { get; set; }

    /// <summary>
    /// The number of periods the offer is active.
    /// </summary>
    [JsonPropertyName("periodCount")]
    public int? PeriodCount { get; set; }

    /// <summary>
    /// The offer price, in milliunits.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/price"/>
    [JsonPropertyName("price")]
    public long? Price { get; set; }

    /// <summary>
    /// The reason for the offer.
    /// </summary>
    [JsonPropertyName("reason")]
    public AdvancedCommerceOfferReason? Reason { get; set; }
}
