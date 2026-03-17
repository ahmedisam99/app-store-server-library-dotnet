using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The type of in-app purchase product.
/// </summary>
[JsonConverter(typeof(JsonEnumMemberConverter<ProductType>))]
public enum ProductType
{
    [EnumMember(Value = "AUTO_RENEWABLE")]
    AutoRenewable,

    [EnumMember(Value = "NON_RENEWABLE")]
    NonRenewable,

    [EnumMember(Value = "CONSUMABLE")]
    Consumable,

    [EnumMember(Value = "NON_CONSUMABLE")]
    NonConsumable
}
