namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The platform on which the customer consumed the in-app purchase.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/platform"/>
public enum Platform
{
    Undeclared = 0,
    Apple = 1,
    NonApple = 2
}
