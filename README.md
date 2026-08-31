[![](https://img.shields.io/nuget/v/soenneker.trulioo.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.trulioo.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.trulioo.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.trulioo.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.trulioo.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.trulioo.openapiclient/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.trulioo.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.trulioo.openapiclient/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Trulioo.OpenApiClient
A Kiota-generated client for Trulioo's Customer API v2.5 authorization and verification flow.

## Installation

```bash
dotnet add package Soenneker.Trulioo.OpenApiClient
```

## Usage

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Trulioo.OpenApiClient;
using Soenneker.Trulioo.OpenApiClient.Models;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://verification.trulioo.com/")
};

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", truliooLicense);

var authentication = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(authentication, httpClient: httpClient);
var trulioo = new TruliooOpenApiClient(adapter);

var request = new PostAuthCustomerRequest
{
    Consent = true,
    ClientId = customerReference,
    Webhook = webhookUrl
};

AuthorizationResponse? authorization =
    await trulioo.Authorize.Customer.PostAsync(request, cancellationToken: cancellationToken);
```

The authorization response contains a short-lived access token for subsequent customer and transaction endpoints. Do not log the license, access token, refresh token, document images, or identity payloads.

Reuse the request adapter and `HttpClient` only while their bearer credential is valid. When moving from the authorization call to transaction calls, use the returned access token rather than continuing to send the license.
