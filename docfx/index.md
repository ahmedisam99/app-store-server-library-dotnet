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
var privateKey = File.ReadAllText("/path/to/key.p8");
var client = new AppStoreServerAPIClient(privateKey, "keyId", "issuerId", "com.example", Environment.Sandbox);

var response = await client.RequestTestNotificationAsync();
```

### Signed Data Verification

```csharp
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

## Using with Dependency Injection

All classes in this library are thread-safe and can be registered as singletons. The DI container will handle disposal at application shutdown for classes that implement `IDisposable`.

The one class that requires special attention is `AppStoreServerAPIClient`, since it uses an `HttpClient` internally. In .NET, managing `HttpClient` lifetimes manually can lead to socket exhaustion or stale DNS issues. The recommended approach is to use `IHttpClientFactory`.

### Registering the API Client

#### Option 1: Named client with a manual factory registration

```csharp
builder.Services.AddHttpClient("AppStoreServer");

builder.Services.AddSingleton(sp =>
{
    var privateKey = File.ReadAllText("/path/to/key.p8");
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("AppStoreServer");

    return new AppStoreServerAPIClient(
        privateKey,
        keyId: "ABCDEFGHIJ",
        issuerId: "99b16628-15e4-4668-972b-eeff55eeff55",
        bundleId: "com.example",
        environment: Environment.Production,
        httpClient: httpClient
    );
});
```

#### Option 2: Typed client with `AddTypedClient`

```csharp
// Registered as transient by default
builder.Services.AddHttpClient<AppStoreServerAPIClient>()
    .AddTypedClient((httpClient) =>
    {
        var privateKey = File.ReadAllText("/path/to/key.p8");

        return new AppStoreServerAPIClient(
            privateKey,
            keyId: "ABCDEFGHIJ",
            issuerId: "99b16628-15e4-4668-972b-eeff55eeff55",
            bundleId: "com.example",
            environment: Environment.Production,
            httpClient: httpClient
        );
    });
```

In both cases, by passing an externally managed `HttpClient`, the `AppStoreServerAPIClient` will not dispose it, leaving lifetime management to the factory.

### Registering Other Services

The remaining classes don't use `HttpClient` and can be registered directly as singletons:

```csharp
builder.Services.AddSingleton(new SignedDataVerifier(
    appleRootCertificates: new[] { File.ReadAllBytes("/path/to/AppleRootCA-G3.cer") },
    enableOnlineChecks: true,
    environment: Environment.Production,
    bundleId: "com.example",
    appAppleId: 123456789
));

builder.Services.AddSingleton<ReceiptUtility>();

builder.Services.AddSingleton(new PromotionalOfferSignatureCreator(
    signingKey: File.ReadAllText("/path/to/key.p8"),
    keyId: "ABCDEFGHIJ",
    bundleId: "com.example"
));
```

## Documentation

- [App Store Server API](https://developer.apple.com/documentation/appstoreserverapi)
- [App Store Server Notifications](https://developer.apple.com/documentation/appstoreservernotifications)
- [Retention Messaging API](https://developer.apple.com/documentation/retentionmessaging)
- [WWDC 2023: Meet the App Store Server Library](https://developer.apple.com/videos/play/wwdc2023/10143/)
