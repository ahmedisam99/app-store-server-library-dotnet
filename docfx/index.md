---
_layout: landing
---

# App Store Server Library for .NET

[API Reference](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.html)

A .NET library for the [App Store Server API](https://developer.apple.com/documentation/appstoreserverapi), [App Store Server Notifications](https://developer.apple.com/documentation/appstoreservernotifications), and [Retention Messaging API](https://developer.apple.com/documentation/retentionmessaging).

## Installation

```bash
dotnet add package Enjna.AppStoreServerLibrary
```

## Quick Start

### API Client

```csharp
using Enjna.AppStoreServerLibrary;
using Enjna.AppStoreServerLibrary.Models;

var encodedKey = File.ReadAllText("/path/to/key/SubscriptionKey_ABCDEFGHIJ.p8");
var client = new AppStoreServerAPIClient(encodedKey, "keyId", "issuerId", "com.example", Environment.Sandbox);

var response = await client.RequestTestNotificationAsync();
```

### Signed Data Verification

```csharp
using Enjna.AppStoreServerLibrary;
using Enjna.AppStoreServerLibrary.Models;

var appleRootCAs = new[] { File.ReadAllBytes("/path/to/AppleRootCA-G3.cer") };
var verifier = new SignedDataVerifier(appleRootCAs, true, Environment.Sandbox, "com.example");

var notification = await verifier.VerifyAndDecodeNotificationAsync(signedPayload);
```

## Available Classes

### App Store Server API Client
[`AppStoreServerAPIClient`](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.AppStoreServerAPIClient.html) - Client for the App Store Server API

### Signed Data Verifier
[`SignedDataVerifier`](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.SignedDataVerifier.html) - Verify and decode signed data from App Store Server API, App Store Server Notifications, and the device

### Receipt Utility
[`ReceiptUtility`](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.ReceiptUtility.html) - Extract transaction identifiers from App Store receipts

### Signature Creators
- [`PromotionalOfferSignatureCreator`](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.PromotionalOfferSignatureCreator.html) - Create promotional offer signatures for the original StoreKit API
- [`PromotionalOfferV2SignatureCreator`](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.PromotionalOfferV2SignatureCreator.html) - Create promotional offer V2 signatures
- [`IntroductoryOfferEligibilitySignatureCreator`](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.IntroductoryOfferEligibilitySignatureCreator.html) - Create introductory offer eligibility signatures
- [`AdvancedCommerceInAppSignatureCreator`](/app-store-server-library-dotnet/api/Enjna.AppStoreServerLibrary.AdvancedCommerceInAppSignatureCreator.html) - Create Advanced Commerce in-app signatures

## Documentation

- [App Store Server API](https://developer.apple.com/documentation/appstoreserverapi)
- [App Store Server Notifications](https://developer.apple.com/documentation/appstoreservernotifications)
- [Retention Messaging API](https://developer.apple.com/documentation/retentionmessaging)
- [WWDC 2023: Meet the App Store Server Library](https://developer.apple.com/videos/play/wwdc2023/10143/)
