using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace AbpCMS.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpCMSBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpCMS";
    }
}
