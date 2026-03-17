using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The type that describes the in-app purchase or external purchase event for which the App Store sends the version 2 notification.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/notificationtype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<NotificationTypeV2>))]
public enum NotificationTypeV2
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that the customer subscribed to an auto-renewable subscription.
    /// If the subtype is <see cref="Subtype.Resubscribe"/>, the customer resubscribed or received access through Family Sharing to the same
    /// subscription or to another subscription within the same subscription group. If the subtype is <see cref="Subtype.InitialBuy"/>, the customer
    /// either purchased or received access through Family Sharing to the subscription for the first time. To determine whether the customer
    /// redeemed an offer, check the
    /// <see href="https://developer.apple.com/documentation/appstoreservernotifications/offertype">offerType</see> in the decoded payload,
    /// <see cref="JWSTransactionDecodedPayload"/>.
    /// <para>For notifications about other product type purchases, see the <see cref="OneTimeCharge"/> notification type.</para>
    /// </summary>
    [EnumMember(Value = "SUBSCRIBED")]
    Subscribed,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that the customer made a change to their subscription plan.
    /// If the subtype is <see cref="Subtype.Upgrade"/>, the customer upgraded their subscription. The upgrade goes into effect immediately,
    /// starting a new billing period, and the customer receives a prorated refund for the unused portion of the previous period. If the subtype
    /// is <see cref="Subtype.Downgrade"/>, the customer downgraded their subscription. Downgrades take effect at the next renewal date and don't
    /// affect the currently active plan.
    /// <para>If the subtype is empty, the customer changed their renewal preference back to the current subscription, effectively canceling a downgrade.</para>
    /// <para>For more information on subscription levels, see
    /// <see href="https://developer.apple.com/app-store/subscriptions/#ranking">Ranking subscriptions within the group</see>.</para>
    /// </summary>
    [EnumMember(Value = "DID_CHANGE_RENEWAL_PREF")]
    DidChangeRenewalPref,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that the customer made a change to the subscription renewal status.
    /// If the subtype is <see cref="Subtype.AutoRenewEnabled"/>, the customer reenabled subscription auto-renewal. If the subtype is
    /// <see cref="Subtype.AutoRenewDisabled"/>, the customer turned off subscription auto-renewal, or the App Store turned off subscription
    /// auto-renewal after the customer requested a refund.
    /// </summary>
    [EnumMember(Value = "DID_CHANGE_RENEWAL_STATUS")]
    DidChangeRenewalStatus,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that a customer with an active subscription redeemed a subscription offer.
    /// <para>If the subtype is <see cref="Subtype.Upgrade"/>, the customer redeemed an offer to upgrade their active subscription, which goes into effect
    /// immediately. If the subtype is <see cref="Subtype.Downgrade"/>, the customer redeemed an offer to downgrade their active subscription, which goes
    /// into effect at the next renewal date. If the customer redeemed an offer for their active subscription, you receive an
    /// <see cref="OfferRedeemed"/> notification type without a subtype.</para>
    /// <para>When customers redeem an offer code for a consumable, non-consumable, or non-renewing subscription, the notification type is
    /// <see cref="OneTimeCharge"/>.</para>
    /// <para>For more information about offer codes, see
    /// <see href="https://developer.apple.com/documentation/StoreKit/supporting-offer-codes-in-your-app">Supporting offer codes in your app</see>.
    /// For more information about promotional offers, see
    /// <see href="https://developer.apple.com/documentation/StoreKit/implementing-promotional-offers-in-your-app">Implementing promotional offers in your app</see>.</para>
    /// </summary>
    [EnumMember(Value = "OFFER_REDEEMED")]
    OfferRedeemed,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that the subscription successfully renewed. If the subtype is
    /// <see cref="Subtype.BillingRecovery"/>, the expired subscription that previously failed to renew has successfully renewed. If the subtype is
    /// empty, the active subscription has successfully auto-renewed for a new transaction period. Provide the customer with access to the
    /// subscription's content or service.
    /// </summary>
    [EnumMember(Value = "DID_RENEW")]
    DidRenew,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that a subscription expired. If the subtype is
    /// <see cref="Subtype.Voluntary"/>, the subscription expired after the customer turned off subscription renewal. If the subtype is
    /// <see cref="Subtype.BillingRetry"/>, the subscription expired because the billing retry period ended without a successful billing
    /// transaction. If the subtype is <see cref="Subtype.PriceIncrease"/>, the subscription expired because the customer didn't consent to a
    /// price increase that requires customer consent. If the subtype is <see cref="Subtype.ProductNotForSale"/>, the subscription expired because
    /// the product wasn't available for purchase at the time the subscription attempted to renew.
    /// <para>A notification without a subtype indicates that the subscription expired for some other reason.</para>
    /// </summary>
    [EnumMember(Value = "EXPIRED")]
    Expired,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that the subscription failed to renew due to a billing issue.
    /// The subscription enters the billing retry period. If the subtype is <see cref="Subtype.GracePeriod"/>, continue to provide service through
    /// the grace period. If the subtype is empty, the subscription isn't in a grace period and you can stop providing the subscription service.
    /// <para>Inform the customer that there may be an issue with their billing information. The App Store continues to retry billing for 60 days,
    /// or until the customer resolves their billing issue or cancels their subscription, whichever comes first. For more information, see
    /// <see href="https://developer.apple.com/documentation/StoreKit/reducing-involuntary-subscriber-churn">Reducing Involuntary Subscriber Churn</see>.</para>
    /// </summary>
    [EnumMember(Value = "DID_FAIL_TO_RENEW")]
    DidFailToRenew,

    /// <summary>
    /// A notification type that indicates that the billing grace period has ended without renewing the subscription, so you can turn off access to
    /// the service or content. Inform the customer that there may be an issue with their billing information. The App Store continues to retry
    /// billing for 60 days, or until the customer resolves their billing issue or cancels their subscription, whichever comes first. For more
    /// information, see
    /// <see href="https://developer.apple.com/documentation/StoreKit/reducing-involuntary-subscriber-churn">Reducing Involuntary Subscriber Churn</see>.
    /// </summary>
    [EnumMember(Value = "GRACE_PERIOD_EXPIRED")]
    GracePeriodExpired,

    /// <summary>
    /// A notification type that, along with its <see cref="Subtype"/>, indicates that the system has informed the customer of an auto-renewable
    /// subscription price increase.
    /// <para>If the price increase requires customer consent, the subtype is <see cref="Subtype.Pending"/> if the customer hasn't responded to
    /// the price increase, or <see cref="Subtype.Accepted"/> if the customer has consented to the price increase.</para>
    /// <para>If the price increase doesn't require customer consent, the subtype is <see cref="Subtype.Accepted"/>.</para>
    /// <para>For information about how the system calls your app before it displays the price consent sheet for subscription price increases
    /// that require customer consent, see
    /// <see href="https://developer.apple.com/documentation/StoreKit/SKPaymentQueueDelegate/paymentQueueShouldShowPriceConsent(_:)">paymentQueueShouldShowPriceConsent(_:)</see>.
    /// For information about managing subscription prices, see
    /// <see href="https://developer.apple.com/documentation/StoreKit/managing-price-increases-for-auto-renewable-subscriptions">Managing Price Increases for Auto-Renewable Subscriptions</see>
    /// and <see href="https://developer.apple.com/app-store/subscriptions/#managing-prices-for-existing-subscribers">Managing Prices</see>.</para>
    /// </summary>
    [EnumMember(Value = "PRICE_INCREASE")]
    PriceIncrease,

    /// <summary>
    /// A notification type that indicates that the App Store successfully refunded a transaction for a consumable In-App Purchase, a non-consumable
    /// In-App Purchase, an auto-renewable subscription, or a non-renewing subscription.
    /// <para>The <see href="https://developer.apple.com/documentation/appstoreservernotifications/revocationdate">revocationDate</see> contains
    /// the timestamp of the refunded transaction. The
    /// <see href="https://developer.apple.com/documentation/appstoreservernotifications/originaltransactionid">originalTransactionId</see> and
    /// <see href="https://developer.apple.com/documentation/appstoreservernotifications/productid">productId</see> identify the original
    /// transaction and product. The
    /// <see href="https://developer.apple.com/documentation/appstoreservernotifications/revocationreason">revocationReason</see> contains
    /// the reason.</para>
    /// <para>To request a list of all refunded transactions for a customer, see
    /// <see href="https://developer.apple.com/documentation/AppStoreServerAPI/Get-Refund-History">Get Refund History</see> in the
    /// <see href="https://developer.apple.com/documentation/AppStoreServerAPI">App Store Server API</see>.</para>
    /// </summary>
    [EnumMember(Value = "REFUND")]
    Refund,

    /// <summary>
    /// A notification type that indicates the App Store declined a refund request.
    /// </summary>
    [EnumMember(Value = "REFUND_DECLINED")]
    RefundDeclined,

    /// <summary>
    /// A notification type that indicates that the customer initiated a refund request for a consumable In-App Purchase or auto-renewable
    /// subscription, and the App Store is requesting that you provide consumption data. For more information, see
    /// <see href="https://developer.apple.com/documentation/AppStoreServerAPI/Send-Consumption-Information">Send Consumption Information</see>.
    /// </summary>
    [EnumMember(Value = "CONSUMPTION_REQUEST")]
    ConsumptionRequest,

    /// <summary>
    /// A notification type that indicates the App Store extended the subscription renewal date for a specific subscription. You request
    /// subscription-renewal-date extensions by calling Extend a Subscription Renewal Date or Extend Subscription Renewal Dates for All Active
    /// Subscribers in the App Store Server API.
    /// </summary>
    [EnumMember(Value = "RENEWAL_EXTENDED")]
    RenewalExtended,

    /// <summary>
    /// A notification type that indicates that an In-App Purchase the customer was entitled to through Family Sharing is no longer available
    /// through sharing. The App Store sends this notification when a purchaser disables Family Sharing for their purchase, the purchaser
    /// (or family member) leaves the family group, or the purchaser receives a refund. Your app also receives a
    /// paymentQueue(_:didRevokeEntitlementsForProductIdentifiers:) call. Family Sharing applies to non-consumable In-App Purchases and
    /// auto-renewable subscriptions. For more information about Family Sharing, see Supporting Family Sharing in your app.
    /// </summary>
    [EnumMember(Value = "REVOKE")]
    Revoke,

    /// <summary>
    /// A notification type that the App Store server sends when you request it by calling the
    /// <see href="https://developer.apple.com/documentation/AppStoreServerAPI/Request-a-Test-Notification">Request a Test Notification</see>
    /// endpoint. Call that endpoint to test whether your server is receiving notifications. You receive this notification only at your request.
    /// For troubleshooting information, see the
    /// <see href="https://developer.apple.com/documentation/AppStoreServerAPI/Get-Test-Notification-Status">Get Test Notification Status</see>
    /// endpoint.
    /// </summary>
    [EnumMember(Value = "TEST")]
    Test,

    /// <summary>
    /// A notification type that, along with its subtype, indicates that the App Store is attempting to extend the subscription renewal date that
    /// you request by calling Extend Subscription Renewal Dates for All Active Subscribers.
    /// <para>If the subtype is <see cref="Subtype.Summary"/>, the App Store completed extending the renewal date for all eligible subscribers.
    /// See the <see cref="Summary"/> in the <see cref="ResponseBodyV2DecodedPayload"/> for details. If the subtype is
    /// <see cref="Subtype.Failure"/>, the renewal date extension didn't succeed for a specific subscription. See the data in the
    /// <see cref="ResponseBodyV2DecodedPayload"/> for details.</para>
    /// </summary>
    [EnumMember(Value = "RENEWAL_EXTENSION")]
    RenewalExtension,

    /// <summary>
    /// A notification type that indicates the App Store reversed a previously granted refund due to a dispute that the customer raised. If your
    /// app revoked content or services as a result of the related refund, it needs to reinstate them.
    /// <para>This notification type can apply to any In-App Purchase type: consumable, non-consumable, non-renewing subscription, and
    /// auto-renewable subscription. For auto-renewable subscriptions, the renewal date remains unchanged when the App Store reverses a refund.</para>
    /// </summary>
    [EnumMember(Value = "REFUND_REVERSED")]
    RefundReversed,

    /// <summary>
    /// A notification type that applies only to apps that use the
    /// <see href="https://developer.apple.com/documentation/StoreKit/external-purchase">External Purchase</see> API to provide alternative
    /// payment options. This notification can have a <see cref="Subtype"/> of CREATED, ACTIVE_TOKEN_REMINDER, or
    /// <see cref="Subtype.Unreported"/>, and includes the external purchase token information,
    /// <see cref="ExternalPurchaseToken"/>.
    /// </summary>
    [EnumMember(Value = "EXTERNAL_PURCHASE_TOKEN")]
    ExternalPurchaseToken,

    /// <summary>
    /// A notification type that indicates the customer purchased a consumable, non-consumable, or non-renewing subscription. The App Store also
    /// sends this notification when the customer receives access to a non-consumable product through Family Sharing. To determine whether the
    /// customer redeemed an offer, check the
    /// <see href="https://developer.apple.com/documentation/appstoreservernotifications/offertype">offerType</see> in the decoded payload,
    /// <see cref="JWSTransactionDecodedPayload"/>.
    /// <para>For notifications about auto-renewable subscription purchases, see the <see cref="Subscribed"/> notification type.</para>
    /// </summary>
    [EnumMember(Value = "ONE_TIME_CHARGE")]
    OneTimeCharge,

    /// <summary>
    /// A notification type that indicates the parent or guardian has withdrawn consent for a child's app usage.
    /// </summary>
    [EnumMember(Value = "RESCIND_CONSENT")]
    RescindConsent,

    /// <summary>
    /// A notification type that indicates you used the
    /// <see href="https://developer.apple.com/documentation/AdvancedCommerceAPI/Change-Subscription-Metadata">Change Subscription Metadata</see>
    /// endpoint to change the metadata for a subscription. This notification only applies to apps that use the
    /// <see href="https://developer.apple.com/documentation/AdvancedCommerceAPI">Advanced Commerce API</see>.
    /// </summary>
    [EnumMember(Value = "METADATA_UPDATE")]
    MetadataUpdate,

    /// <summary>
    /// A notification type that indicates you used the
    /// <see href="https://developer.apple.com/documentation/AdvancedCommerceAPI/Migrate-Subscription-to-Advanced-Commerce-API">Migrate a Subscription to Advanced Commerce API</see>
    /// endpoint. This notification only applies to apps that use the
    /// <see href="https://developer.apple.com/documentation/AdvancedCommerceAPI">Advanced Commerce API</see>.
    /// </summary>
    [EnumMember(Value = "MIGRATION")]
    Migration,

    /// <summary>
    /// A notification type that indicates that you called the
    /// <see href="https://developer.apple.com/documentation/AdvancedCommerceAPI/Change-Subscription-Price">Change Subscription Price</see>
    /// endpoint. This notification only applies to apps that use the
    /// <see href="https://developer.apple.com/documentation/AdvancedCommerceAPI">Advanced Commerce API</see>.
    /// </summary>
    [EnumMember(Value = "PRICE_CHANGE")]
    PriceChange
}
