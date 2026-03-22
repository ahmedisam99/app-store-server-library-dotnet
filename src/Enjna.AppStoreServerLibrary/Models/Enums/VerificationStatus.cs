namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The status of a verification attempt.
/// </summary>
public enum VerificationStatus
{
    Ok,
    VerificationFailure,
    RetryableVerificationFailure,
    InvalidBundleId,
    InvalidAppAppleId,
    InvalidEnvironment,
    InvalidChainLength,
    InvalidCertificate,
    Failure
}
