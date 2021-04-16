using FlexiSourceTestApp.Service;
using Microsoft.Extensions.DependencyInjection;

namespace FlexiSourceTestApp.Config
{
    public static class ServiceUtilities
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITextService, TextService>();
        }

    }
}
