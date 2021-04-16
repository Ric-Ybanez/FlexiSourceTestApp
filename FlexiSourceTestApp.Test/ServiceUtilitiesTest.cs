using FlexiSourceTestApp.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FlexiSourceTestApp.Test
{
    public class ServiceUtilitiestest
    {
        [Fact]
        public void AddServices_ReturnsVoid()
        {
            var expectedColCount = 1;
            var collection = new ServiceCollection();

            collection.AddServices();
            Assert.Equal(expectedColCount, collection.Count);
        }
    }
}
