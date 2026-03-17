using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The error response body returned by the App Store Server API.
/// </summary>
public sealed class ErrorResponseBody
{
    [JsonPropertyName("errorCode")] public int? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")] public string? ErrorMessage { get; set; }
}
