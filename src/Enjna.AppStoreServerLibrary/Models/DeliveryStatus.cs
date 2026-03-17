using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A value that indicates whether the app successfully delivered an In-App Purchase that works properly.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/deliverystatus"/>
[JsonConverter(typeof(JsonEnumMemberConverter<DeliveryStatus>))]
public enum DeliveryStatus
{
    /// <summary>
    /// The app delivered the In-App Purchase and it's working properly.
    /// </summary>
    [EnumMember(Value = "DELIVERED")]
    Delivered,

    /// <summary>
    /// The app didn't deliver the In-App Purchase due to a quality issue.
    /// </summary>
    [EnumMember(Value = "UNDELIVERED_QUALITY_ISSUE")]
    UndeliveredQualityIssue,

    /// <summary>
    /// The app delivered the wrong item.
    /// </summary>
    [EnumMember(Value = "UNDELIVERED_WRONG_ITEM")]
    UndeliveredWrongItem,

    /// <summary>
    /// The app didn't deliver the In-App Purchase due to a server outage.
    /// </summary>
    [EnumMember(Value = "UNDELIVERED_SERVER_OUTAGE")]
    UndeliveredServerOutage,

    /// <summary>
    /// The app didn't deliver the In-App Purchase for other reasons.
    /// </summary>
    [EnumMember(Value = "UNDELIVERED_OTHER")]
    UndeliveredOther
}
