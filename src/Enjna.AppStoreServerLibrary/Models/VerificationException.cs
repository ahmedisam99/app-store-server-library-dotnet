using System;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An exception thrown when signed data verification fails.
/// </summary>
public sealed class VerificationException : Exception
{
    /// <summary>
    /// The verification status that describes the failure reason.
    /// </summary>
    public VerificationStatus Status { get; }

    public VerificationException(VerificationStatus status, Exception? innerException = null)
        : base($"Verification failed with status: {status}", innerException)
    {
        Status = status;
    }
}
