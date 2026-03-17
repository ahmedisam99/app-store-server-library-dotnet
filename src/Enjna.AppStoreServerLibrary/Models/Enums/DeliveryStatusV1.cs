using System;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// A value that indicates whether the app successfully delivered an in-app purchase that works properly.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/deliverystatusv1"/>
[Obsolete("Use DeliveryStatus instead.")]
public enum DeliveryStatusV1
{
    DeliveredAndWorkingProperly = 0,
    DidNotDeliverDueToQualityIssue = 1,
    DeliveredWrongItem = 2,
    DidNotDeliverDueToServerOutage = 3,
    DidNotDeliverDueToInGameCurrencyChange = 4,
    DidNotDeliverForOtherReason = 5
}
