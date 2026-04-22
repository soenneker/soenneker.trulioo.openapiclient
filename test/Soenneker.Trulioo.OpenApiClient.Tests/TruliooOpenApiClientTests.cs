using Soenneker.Tests.HostedUnit;

namespace Soenneker.Trulioo.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TruliooOpenApiClientTests : HostedUnitTest
{
    public TruliooOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
