using Xunit;

namespace MySkyNetApp.Api.IntegrationTests.Utils
{
    [CollectionDefinition(nameof(TestFixtureCollection))]
    public class TestFixtureCollection : ICollectionFixture<TestFixture<Startup>>
    {

    }
}