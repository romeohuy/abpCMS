using AbpCMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpCMS.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpCMSController : AbpController
    {
        protected AbpCMSController()
        {
            LocalizationResource = typeof(AbpCMSResource);
        }
    }
}