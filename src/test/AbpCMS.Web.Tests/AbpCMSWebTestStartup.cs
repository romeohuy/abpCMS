using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AbpCMS
{
    public class AbpCMSWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AbpCMSWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
