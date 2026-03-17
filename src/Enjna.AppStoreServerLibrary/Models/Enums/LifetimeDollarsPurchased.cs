namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// A value that indicates the total amount, in USD, of in-app purchases the customer has made in your app, across all platforms.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/lifetimedollarspurchased"/>
public enum LifetimeDollarsPurchased
{
    Undeclared = 0,
    ZeroDollars = 1,
    OneCentToFortyNineDollarsAndNinetyNineCents = 2,
    FiftyDollarsToNinetyNineDollarsAndNinetyNineCents = 3,
    OneHundredDollarsToFourHundredNinetyNineDollarsAndNinetyNineCents = 4,
    FiveHundredDollarsToNineHundredNinetyNineDollarsAndNinetyNineCents = 5,
    OneThousandDollarsToOneThousandNineHundredNinetyNineDollarsAndNinetyNineCents = 6,
    TwoThousandDollarsOrGreater = 7
}
