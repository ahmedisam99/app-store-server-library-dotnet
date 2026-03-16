namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The status that indicates whether an auto-renewable subscription is subject to a price increase.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/priceincreasestatus"/>
public enum PriceIncreaseStatus
{
    CustomerHasNotResponded = 0,
    CustomerConsentedOrWasNotifiedWithoutNeedingConsent = 1
}
