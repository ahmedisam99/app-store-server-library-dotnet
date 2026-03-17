using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The type of in-app purchase products you can offer in your app.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/type"/>
[JsonConverter(typeof(JsonEnumMemberConverter<Type>))]
public enum Type
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// An auto-renewable subscription.
    /// </summary>
    [EnumMember(Value = "Auto-Renewable Subscription")]
    AutoRenewableSubscription,

    /// <summary>
    /// A non-consumable In-App Purchase.
    /// </summary>
    [EnumMember(Value = "Non-Consumable")]
    NonConsumable,

    /// <summary>
    /// A consumable In-App Purchase.
    /// </summary>
    [EnumMember(Value = "Consumable")]
    Consumable,

    /// <summary>
    /// A non-renewing subscription.
    /// </summary>
    [EnumMember(Value = "Non-Renewing Subscription")]
    NonRenewingSubscription
}
