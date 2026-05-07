using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The billing plan type that applies at the next subscription renewal.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/renewalbillingplantype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<RenewalBillingPlanType>))]
public enum RenewalBillingPlanType
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
