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
    [EnumMember(Value = "DELIVERED")]
    Delivered,

    [EnumMember(Value = "UNDELIVERED_QUALITY_ISSUE")]
    UndeliveredQualityIssue,

    [EnumMember(Value = "UNDELIVERED_WRONG_ITEM")]
    UndeliveredWrongItem,

    [EnumMember(Value = "UNDELIVERED_SERVER_OUTAGE")]
    UndeliveredServerOutage,

    [EnumMember(Value = "UNDELIVERED_OTHER")]
    UndeliveredOther
}
