using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpCMS.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpCMSEntityFrameworkCoreModule)
    )]
    public class AbpCMSEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpCMSMigrationsDbContext>();
        }
    }
}