using Microsoft.AspNetCore.Mvc;

namespace AbpCMS.Web.Pages
{
    public class IndexModel : AbpCMSPageModel
    {
        public ActionResult OnGet()
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Redirect("~/Account/Login");
            }

            return Page();
        }
    }
}