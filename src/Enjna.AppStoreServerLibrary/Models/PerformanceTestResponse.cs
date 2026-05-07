using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The performance test response object.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestresponse"/>
public sealed class PerformanceTestResponse
{
    /// <summary>
    /// The performance test configuration object.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestconfig"/>
    [JsonPropertyName("config")]
    public PerformanceTestConfig? Config { get; set; }

    /// <summary>
    /// The performance test request identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/requestid"/>
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }
}
