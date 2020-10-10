using Volo.Abp.Modularity;

namespace AbpCMS
{
    [DependsOn(
        typeof(AbpCMSApplicationModule),
        typeof(AbpCMSDomainTestModule)
        )]
    public class AbpCMSApplicationTestModule : AbpModule
    {

    }
}