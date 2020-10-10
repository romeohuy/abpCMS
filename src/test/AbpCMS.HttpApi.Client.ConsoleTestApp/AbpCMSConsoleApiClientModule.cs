using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpCMS.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(AbpCMSHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpCMSConsoleApiClientModule : AbpModule
    {
        
    }
}
