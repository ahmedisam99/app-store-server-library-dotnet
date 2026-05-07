using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An object that enumerates the test configuration parameters.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestconfig"/>
public sealed class PerformanceTestConfig
{
    /// <summary>
    /// The maximum number of concurrent requests the API allows.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/maxconcurrentrequests"/>
    [JsonPropertyName("maxConcurrentRequests")]
    public long? MaxConcurrentRequests { get; set; }

    /// <summary>
    /// The total number of requests to make during the test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/totalrequests"/>
    [JsonPropertyName("totalRequests")]
    public long? TotalRequests { get; set; }

    /// <summary>
    /// The total duration of the test in milliseconds.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/totalduration"/>
    [JsonPropertyName("totalDuration")]
    public long? TotalDuration { get; set; }

    /// <summary>
    /// The maximum time your server has to respond when the system calls your Get Retention Message endpoint in the sandbox environment.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/responsetimethreshold"/>
    [JsonPropertyName("responseTimeThreshold")]
    public long? ResponseTimeThreshold { get; set; }

    /// <summary>
    /// The success rate threshold percentage.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/successratethreshold"/>
    [JsonPropertyName("successRateThreshold")]
    public long? SuccessRateThreshold { get; set; }
}
