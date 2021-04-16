using FlexiSourceTestApp.Service;
using Moq;

namespace FlexiSourceTestApp.Test.Controller.Shared
{
    public static class MockServiceGenerator
    {
        public static Mock<ITextService> GetMockTextService() => new Mock<ITextService>();
    }
}