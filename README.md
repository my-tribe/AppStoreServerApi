# AppStoreServerApi

A .net 8.0 library to request [App Store Server API](https://developer.apple.com/documentation/appstoreserverapi).

This library is already working but work is still in progress. Don't hesitate to contribute if you see any possible improvment or fixes.

## Features
- Implemented all apis corresponding to App Store Server API [verison 1.15](https://developer.apple.com/documentation/appstoreserverapi/app-store-server-api-changelog#115-20250221)
- Typed responses
- Manages authentication tokens for you

## Installation
The library is available on NuGet. You can install it using the following command:
```console
dotnet add package MyTribe.AppStoreServerApi
```

## Usage
### Prerequisites
To get started, you must obtain the following:
- An [API key](https://developer.apple.com/documentation/appstoreserverapi/creating_api_keys_to_use_with_the_app_store_server_api)
- The ID of the key
- Your [issuer ID](https://developer.apple.com/documentation/appstoreserverapi/generating_tokens_for_api_requests)

A note on the issuer ID:
Apple's documentation currently has incorrect instructions on how to obtain this.
To get your issuer ID, you must [create an API key for App Store Connect](https://developer.apple.com/documentation/appstoreconnectapi/creating_api_keys_for_app_store_connect_api) (not the App Store Server API). Only after creating your first API key will the issuer ID appear.

### Create a client
```csharp
var environment = AppleEnvironment.Production;
var privateKey = @"-----BEGIN PRIVATE KEY-----
....
-----END PRIVATE KEY-----";
var keyId = "2X9R4HXF34";
var issuerId = "57246542-96fe-1a63-e053-0824d011072a";
var bundleId = "com.example.testbundleid";

var client = new AppStoreClient(environment, privateKey, keyId, issuerId, bundleId);
```

## Links
[App Store Server API](https://developer.apple.com/documentation/appstoreserverapi)
[App Store Server API changelog](https://developer.apple.com/documentation/appstoreserverapi/app_store_server_api_changelog)
