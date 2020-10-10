using AbpCMS.Localization;
using Volo.Abp.Application.Services;

namespace AbpCMS
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpCMSAppService : ApplicationService
    {
        protected AbpCMSAppService()
        {
            LocalizationResource = typeof(AbpCMSResource);
        }
    }
}
