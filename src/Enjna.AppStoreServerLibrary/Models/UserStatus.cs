namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The status of a customer's account within your app.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/userstatus"/>
public enum UserStatus
{
    Undeclared = 0,
    Active = 1,
    Suspended = 2,
    Terminated = 3,
    LimitedAccess = 4
}
