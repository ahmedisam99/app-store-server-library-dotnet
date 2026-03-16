namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The reason for a refunded transaction.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/revocationreason"/>
public enum RevocationReason
{
    RefundedForOtherReason = 0,
    RefundedDueToIssue = 1
}
