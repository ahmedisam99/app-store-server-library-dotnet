using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The base type for decoded signed data.
/// </summary>
public abstract class DecodedSignedData
{
    /// <summary>
    /// The UNIX time, in milliseconds, that the App Store signed the JSON Web Signature data.
    /// </summary>
    [JsonPropertyName("signedDate")]
    public long? SignedDate { get; set; }
}
