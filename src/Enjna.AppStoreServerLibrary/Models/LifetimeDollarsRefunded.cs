namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A value that indicates the dollar amount of refunds the customer has received in your app, since purchasing the app, across all platforms.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/lifetimedollarsrefunded"/>
public enum LifetimeDollarsRefunded
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
