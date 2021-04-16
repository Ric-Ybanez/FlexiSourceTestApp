using FlexiSourceTestApp.Service;

namespace FlexiSourceTestApp.Test.Services.Shared
{
    public static class ServiceGenerator
    {
        public static TextService GetTextService()
        {
            var service = new TextService();
            return service;
        }
    }
}
