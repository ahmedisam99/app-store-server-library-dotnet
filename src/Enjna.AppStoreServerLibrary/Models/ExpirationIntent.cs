namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The reason an auto-renewable subscription expired.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/expirationintent"/>
public enum ExpirationIntent
{
    CustomerCancelled = 1,
    BillingError = 2,
    CustomerDidNotConsentToPriceIncrease = 3,
    ProductNotAvailable = 4,
    Other = 5
}
