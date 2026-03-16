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
    [EnumMember(Value = "Auto-Renewable Subscription")]
    AutoRenewableSubscription,

    [EnumMember(Value = "Non-Consumable")]
    NonConsumable,

    [EnumMember(Value = "Consumable")]
    Consumable,

    [EnumMember(Value = "Non-Renewing Subscription")]
    NonRenewingSubscription
}
