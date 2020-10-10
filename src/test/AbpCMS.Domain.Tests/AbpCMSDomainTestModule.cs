using AbpCMS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpCMS
{
    [DependsOn(
        typeof(AbpCMSEntityFrameworkCoreTestModule)
        )]
    public class AbpCMSDomainTestModule : AbpModule
    {

    }
}