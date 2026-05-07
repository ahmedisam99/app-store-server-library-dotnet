using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An object that describes test response times.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestresponsetimes"/>
public sealed class PerformanceTestResponseTimes
{
    /// <summary>
    /// Average response time in milliseconds.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/average"/>
    [JsonPropertyName("average")]
    public long? Average { get; set; }

    /// <summary>
    /// The 50th percentile response time in milliseconds.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/p50"/>
    [JsonPropertyName("p50")]
    public long? P50 { get; set; }

    /// <summary>
    /// The 90th percentile response time in milliseconds.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/p90"/>
    [JsonPropertyName("p90")]
    public long? P90 { get; set; }

    /// <summary>
    /// The 95th percentile response time in milliseconds.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/p95"/>
    [JsonPropertyName("p95")]
    public long? P95 { get; set; }

    /// <summary>
    /// The 99th percentile response time in milliseconds.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/p99"/>
    [JsonPropertyName("p99")]
    public long? P99 { get; set; }
}
