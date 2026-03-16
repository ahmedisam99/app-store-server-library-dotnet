using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The relationship of the user with the family-shared purchase to which they have access.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/inappownershiptype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<InAppOwnershipType>))]
public enum InAppOwnershipType
{
    [EnumMember(Value = "FAMILY_SHARED")]
    FamilyShared,

    [EnumMember(Value = "PURCHASED")]
    Purchased
}
