using System;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A value that indicates your preferred outcome for the refund request.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/refundpreferencev1"/>
[Obsolete("Use RefundPreference instead.")]
public enum RefundPreferenceV1
{
    Undeclared = 0,
    PreferGrant = 1,
    PreferDecline = 2,
    NoPreference = 3
}
