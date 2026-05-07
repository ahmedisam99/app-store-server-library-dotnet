using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Transaction commitment information.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/transactioncommitmentinfo"/>
public sealed class TransactionCommitmentInfo
{
    /// <summary>
    /// The number of the current billing period within the commitment.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/billingperiodnumber"/>
    [JsonPropertyName("billingPeriodNumber")]
    public int? BillingPeriodNumber { get; set; }

    /// <summary>
    /// The UNIX time, in milliseconds, when the commitment expires.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/commitmentexpiresdate"/>
    [JsonPropertyName("commitmentExpiresDate")]
    public long? CommitmentExpiresDate { get; set; }

    /// <summary>
    /// The price of the commitment, in milliunits.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/commitmentprice"/>
    [JsonPropertyName("commitmentPrice")]
    public long? CommitmentPrice { get; set; }

    /// <summary>
    /// The total number of billing periods covered by the commitment.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/totalbillingperiods"/>
    [JsonPropertyName("totalBillingPeriods")]
    public int? TotalBillingPeriods { get; set; }
}
