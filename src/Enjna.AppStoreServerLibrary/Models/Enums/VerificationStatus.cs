namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The status of a verification attempt.
/// </summary>
public enum VerificationStatus
{
    Ok,
    VerificationFailure,
    RetryableVerificationFailure,
    InvalidAppIdentifier,
    InvalidEnvironment,
    InvalidChainLength,
    InvalidCertificate,
    Failure
}
