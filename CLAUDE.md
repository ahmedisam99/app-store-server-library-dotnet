# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What This Is

A community-maintained .NET 8.0 port of Apple's [App Store Server Library](https://github.com/apple/app-store-server-library-node). The reference Node.js implementation is vendored as a git submodule at `vendor/app-store-server-library-node/` for parity checks.

## Build & Test Commands

```bash
dotnet build                    # Build the solution
dotnet test                     # Run all tests
dotnet run --project test/Enjna.AppStoreServerLibrary.Tests  # Run tests directly (verbose output)
```

To run a filtered subset of tests (xunit.v3 syntax):
```bash
dotnet run --project test/Enjna.AppStoreServerLibrary.Tests -- --filter-method "*MethodName*"
```

## Architecture

### Core Services (`src/Enjna.AppStoreServerLibrary/`)

- **`AppStoreServerAPIClient`**: HTTP client for Apple's App Store Server API. Creates bearer tokens with ECDsa-signed JWTs. All public methods accept an optional `bundleId` override parameter, threaded through `MakeRequestAsync` → `CreateBearerToken`.
- **`SignedDataVerifier`**: Verifies and decodes Apple-signed JWTs (transactions, renewal info, notifications, app transactions, realtime requests). Performs X.509 certificate chain validation with optional OCSP checking and caching.
- **`JWSSignatureCreator`**: Abstract base for creating signed JWS tokens. Subclasses:
  - `PromotionalOfferV2SignatureCreator`
  - `IntroductoryOfferEligibilitySignatureCreator`
  - `AdvancedCommerceInAppSignatureCreator`.
- **`PromotionalOfferSignatureCreator`**: Standalone (not a JWSSignatureCreator subclass). Creates legacy V1 promotional offer signatures using raw ECDSA over a separator-joined payload.
- **`ReceiptUtility`**: Extracts transaction IDs from legacy app receipts and transaction receipts.

### Models (`src/Enjna.AppStoreServerLibrary/Models/`)

- Data models are simple classes.
- Enums live in `Models/Enums/`.
- String-backed enums use `JsonEnumMemberConverter<T>`, `[EnumMember]`, and include an `_Unmapped` sentinel value for forward-compatibility with unknown API values.
- Integer-backed enums (e.g., `Status`, `OfferType`) do not use the custom converter.

### Tests (`test/Enjna.AppStoreServerLibrary.Tests/`)

- **xunit.v3** with .NET Testing Platform (`TestingPlatformDotnetTestSupport`).
- Test resources are **embedded resources** loaded via `TestUtilities.ReadResourceAsString()` / `ReadResourceAsBytes()` using dot-separated paths (e.g., `"models.signedTransaction.json"`).
- `TestUtilities.CreateSignedDataFromJson()` wraps JSON fixtures in ephemeral ES256 JWTs for decoding tests.
- `TestUtilities.GetDefaultSignedPayloadVerifier()` creates a verifier with `Environment.LocalTesting` which **skips certificate chain validation entirely**, allowing tests to decode payloads without real Apple credentials.

## Code Conventions

- **File-scoped namespaces**, explicit imports (no implicit usings).
- **`ConfigureAwait(false)`** on all async calls.
- **`base.`** prefix when calling inherited methods from subclasses.
- XML doc comments on all public members (build generates documentation file).

## Parity with Node.js Reference

Use the `dotnet-parity-checker` agent (`.claude/agents/dotnet-parity-checker.md`) to verify the .NET implementation matches the vendored Node.js reference.
