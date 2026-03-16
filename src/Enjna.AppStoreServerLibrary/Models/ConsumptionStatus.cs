namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A value that indicates the extent to which the customer consumed the in-app purchase.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/consumptionstatus"/>
public enum ConsumptionStatus
{
    Undeclared = 0,
    NotConsumed = 1,
    PartiallyConsumed = 2,
    FullyConsumed = 3
}
