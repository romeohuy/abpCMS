using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpCMS.CompanyDatas;
using Microsoft.AspNetCore.Mvc;

namespace AbpCMS.Web.Pages
{
    public class IndexModel : AbpCMSPageModel
    {
        private readonly ICompanyDataAppService _companyDataAppService;

        public IndexModel(ICompanyDataAppService companyDataAppService)
        {
            _companyDataAppService = companyDataAppService;
        }

        public List<CompanyDataWithNavigationPropertiesDto> CompaniesData { get; set; }
        public async Task<ActionResult> OnGet()
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Redirect("~/Account/Login");
            }

            CompaniesData = (await _companyDataAppService.GetListAsync(new GetCompanyDatasInput())).Items.ToList();
            return Page();
        }
    }
}