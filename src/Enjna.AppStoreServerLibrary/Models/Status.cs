namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The status of an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/status"/>
public enum Status
{
    Active = 1,
    Expired = 2,
    BillingRetry = 3,
    BillingGracePeriod = 4,
    Revoked = 5
}
