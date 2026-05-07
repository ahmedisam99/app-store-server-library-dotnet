using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request object you provide for a performance test that contains an original transaction identifier.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performancetestrequest"/>
public sealed class PerformanceTestRequest
{
    /// <summary>
    /// The original transaction identifier of an In-App Purchase you initiate in the sandbox environment, to use as the purchase for this test.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/originaltransactionid"/>
    [JsonPropertyName("originalTransactionId")]
    public required string OriginalTransactionId { get; set; }
}
