namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A value that indicates whether the order ID in the request is valid for your app.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/orderlookupstatus"/>
public enum OrderLookupStatus
{
    Valid = 0,
    Invalid = 1
}
