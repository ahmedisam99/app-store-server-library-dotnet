# App Store Server Library for .NET

A .NET library for the [App Store Server API](https://developer.apple.com/documentation/appstoreserverapi), [App Store Server Notifications](https://developer.apple.com/documentation/appstoreservernotifications), and [Retention Messaging API](https://developer.apple.com/documentation/retentionmessaging).

> This is a community-maintained library and is not affiliated with Apple. For official libraries, see [Swift](https://github.com/apple/app-store-server-library-swift), [Node.js](https://github.com/apple/app-store-server-library-node), [Python](https://github.com/apple/app-store-server-library-python), and [Java](https://github.com/apple/app-store-server-library-java).

## Table of Contents

1. [Installation](#installation)
2. [Documentation](#documentation)
3. [Usage](#usage)

## Installation

### Requirements

- .NET 8.0+

### NuGet

```bash
dotnet add package Enjna.AppStoreServerLibrary
```

## Documentation

[Documentation](https://ahmedisam99.github.io/app-store-server-library-dotnet/index.html)

[WWDC Video](https://developer.apple.com/videos/play/wwdc2023/10143/)

### Obtaining an In-App Purchase key from App Store Connect

To use the App Store Server API or create promotional offer signatures, a signing key downloaded from App Store Connect is required. To obtain this key, you must have the Admin role. Go to Users and Access > Integrations > In-App Purchase. Here you can create and manage keys, as well as find your issuer ID. When using a key, you'll need the key ID and issuer ID as well.

### Obtaining Apple Root Certificates

Download and store the root certificates found in the Apple Root Certificates section of the [Apple PKI](https://www.apple.com/certificateauthority/) site. Provide these certificates as an array to a `SignedDataVerifier` to allow verifying the signed data comes from Apple.

## Usage

### API Usage

```csharp
using Enjna.AppStoreServerLibrary;
using Enjna.AppStoreServerLibrary.Models;

var issuerId = "99b16628-15e4-4668-972b-eeff55eeff55";
var keyId = "ABCDEFGHIJ";
var bundleId = "com.example";
var encodedKey = File.ReadAllText("/path/to/key/SubscriptionKey_ABCDEFGHIJ.p8");
var environment = Environment.Sandbox;

var client = new AppStoreServerAPIClient(encodedKey, keyId, issuerId, bundleId, environment);

var response = await client.RequestTestNotificationAsync();
Console.WriteLine(response.TestNotificationToken);
```

### Verification Usage

```csharp
using Enjna.AppStoreServerLibrary;
using Enjna.AppStoreServerLibrary.Models;

var bundleId = "com.example";
var appleRootCAs = new[] { File.ReadAllBytes("/path/to/AppleRootCA-G3.cer") };
var enableOnlineChecks = true;
var environment = Environment.Sandbox;
long? appAppleId = null; // appAppleId is required when the environment is Production

var verifier = new SignedDataVerifier(appleRootCAs, enableOnlineChecks, environment, bundleId, appAppleId);

var notificationPayload = "ey...";
var verifiedNotification = await verifier.VerifyAndDecodeNotificationAsync(notificationPayload);
Console.WriteLine(verifiedNotification.NotificationType);
```

### Receipt Usage

```csharp
using Enjna.AppStoreServerLibrary;
using Enjna.AppStoreServerLibrary.Models;

var issuerId = "99b16628-15e4-4668-972b-eeff55eeff55";
var keyId = "ABCDEFGHIJ";
var bundleId = "com.example";
var encodedKey = File.ReadAllText("/path/to/key/SubscriptionKey_ABCDEFGHIJ.p8");
var environment = Environment.Sandbox;

var client = new AppStoreServerAPIClient(encodedKey, keyId, issuerId, bundleId, environment);

var appReceipt = "MI...";
var receiptUtility = new ReceiptUtility();
var transactionId = receiptUtility.ExtractTransactionIdFromAppReceipt(appReceipt);
if (transactionId is not null)
{
    var request = new TransactionHistoryRequest
    {
        Sort = Order.Ascending,
        Revoked = false,
        ProductTypes = [ProductType.AutoRenewable]
    };

    HistoryResponse? response = null;
    var transactions = new List<string>();
    do
    {
        var revision = response?.Revision;
        response = await client.GetTransactionHistoryAsync(transactionId, revision, request);
        if (response.SignedTransactions is not null)
        {
            transactions.AddRange(response.SignedTransactions);
        }
    } while (response.HasMore);

    Console.WriteLine($"Found {transactions.Count} transactions");
}
```

### Promotional Offer Signature Creation

```csharp
using Enjna.AppStoreServerLibrary;

var keyId = "ABCDEFGHIJ";
var bundleId = "com.example";
var encodedKey = File.ReadAllText("/path/to/key/SubscriptionKey_ABCDEFGHIJ.p8");

var productId = "<product_id>";
var subscriptionOfferId = "<subscription_offer_id>";
var appAccountToken = "<app_account_token>";
var nonce = Guid.NewGuid();
var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

using var signatureCreator = new PromotionalOfferSignatureCreator(encodedKey, keyId, bundleId);
var signature = signatureCreator.CreateSignature(productId, subscriptionOfferId, appAccountToken, nonce, timestamp);
Console.WriteLine(signature);
```
