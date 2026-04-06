using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Trulioo.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class TruliooOpenApiClientTests : FixturedUnitTest
{
    public TruliooOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
