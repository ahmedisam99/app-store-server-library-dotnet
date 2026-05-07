using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The billing plan type for a subscription transaction.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/billingplantype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<BillingPlanType>))]
public enum BillingPlanType
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The subscription is billed upfront for the full commitment period.
    /// </summary>
    [EnumMember(Value = "BILLED_UPFRONT")]
    BilledUpfront,

    /// <summary>
    /// The subscription is billed monthly.
    /// </summary>
    [EnumMember(Value = "MONTHLY")]
    Monthly
}
