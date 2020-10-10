using AbpCMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpCMS.Web.Pages
{
    public abstract class AbpCMSPageModel : AbpPageModel
    {
        protected AbpCMSPageModel()
        {
            LocalizationResourceType = typeof(AbpCMSResource);
        }
    }
}