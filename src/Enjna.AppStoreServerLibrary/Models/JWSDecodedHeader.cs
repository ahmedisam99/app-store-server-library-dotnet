using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The decoded header of a JSON Web Signature.
/// </summary>
internal sealed class JWSDecodedHeader
{
    [JsonPropertyName("alg")]
    public string? Alg { get; set; }

    [JsonPropertyName("x5c")]
    public string[]? X5C { get; set; }
}
