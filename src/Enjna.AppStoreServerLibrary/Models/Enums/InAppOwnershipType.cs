using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The relationship of the user with the family-shared purchase to which they have access.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/inappownershiptype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<InAppOwnershipType>))]
public enum InAppOwnershipType
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The transaction belongs to a family member who benefits from service.
    /// </summary>
    [EnumMember(Value = "FAMILY_SHARED")]
    FamilyShared,

    /// <summary>
    /// The transaction belongs to the purchaser.
    /// </summary>
    [EnumMember(Value = "PURCHASED")]
    Purchased
}
