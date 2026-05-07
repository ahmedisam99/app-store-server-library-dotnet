using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Renewal commitment information for a subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/renewalcommitmentinfo"/>
public sealed class RenewalCommitmentInfo
{
    /// <summary>
    /// The product identifier the subscription will switch to at commitment renewal.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/commitmentautorenewproductid"/>
    [JsonPropertyName("commitmentAutoRenewProductId")]
    public string? CommitmentAutoRenewProductId { get; set; }

    /// <summary>
    /// The auto-renew status that applies at commitment renewal.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/commitmentautorenewstatus"/>
    [JsonPropertyName("commitmentAutoRenewStatus")]
    public AutoRenewStatus? CommitmentAutoRenewStatus { get; set; }

    /// <summary>
    /// The renewal billing plan type that applies at commitment renewal.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/commitmentrenewalbillingplantype"/>
    [JsonPropertyName("commitmentRenewalBillingPlanType")]
    public RenewalBillingPlanType? CommitmentRenewalBillingPlanType { get; set; }

    /// <summary>
    /// The UNIX time, in milliseconds, of the commitment renewal date.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/commitmentrenewaldate"/>
    [JsonPropertyName("commitmentRenewalDate")]
    public long? CommitmentRenewalDate { get; set; }

    /// <summary>
    /// The renewal price, in milliunits, that applies at commitment renewal.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/commitmentrenewalprice"/>
    [JsonPropertyName("commitmentRenewalPrice")]
    public long? CommitmentRenewalPrice { get; set; }
}
