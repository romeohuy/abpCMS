using AbpCMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpCMS.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpCMSEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpCMSApplicationContractsModule)
    )]
    public class AbpCMSDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}