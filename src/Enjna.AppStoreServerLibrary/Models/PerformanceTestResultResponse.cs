using System.Collections.Generic;
using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An object the API returns that describes the performance test results.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestresultresponse"/>
public sealed class PerformanceTestResultResponse
{
    /// <summary>
    /// A <see cref="PerformanceTestConfig"/> object that enumerates the test parameters.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestconfig"/>
    [JsonPropertyName("config")]
    public PerformanceTestConfig? Config { get; set; }

    /// <summary>
    /// The target URL for the performance test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/target"/>
    [JsonPropertyName("target")]
    public string? Target { get; set; }

    /// <summary>
    /// A <see cref="PerformanceTestStatus"/> value that describes the overall result of the test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performanceteststatus"/>
    [JsonPropertyName("result")]
    public PerformanceTestStatus? Result { get; set; }

    /// <summary>
    /// An integer that describes the success rate percentage of the performance test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/successrate"/>
    [JsonPropertyName("successRate")]
    public long? SuccessRate { get; set; }

    /// <summary>
    /// An integer that describes the number of pending requests in the performance test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/numpending"/>
    [JsonPropertyName("numPending")]
    public long? NumPending { get; set; }

    /// <summary>
    /// A <see cref="PerformanceTestResponseTimes"/> object that enumerates the response times measured during the test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestresponsetimes"/>
    [JsonPropertyName("responseTimes")]
    public PerformanceTestResponseTimes? ResponseTimes { get; set; }

    /// <summary>
    /// A map of server-to-server notification failure reasons and counts that represent the number of failures during a performance test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/failures"/>
    [JsonPropertyName("failures")]
    public Dictionary<string, long>? Failures { get; set; }
}
