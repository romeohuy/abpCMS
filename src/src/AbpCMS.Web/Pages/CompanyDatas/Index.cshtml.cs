using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using AbpCMS.CompanyDatas;
using AbpCMS.Shared;

namespace AbpCMS.Web.Pages.CompanyDatas
{
    public class IndexModel : AbpPageModel
    {
        public string TitleFilter { get; set; }
        public string ShortDescriptionFilter { get; set; }
        public string ContentFilter { get; set; }

        private readonly ICompanyDataAppService _companyDataAppService;

        public IndexModel(ICompanyDataAppService companyDataAppService)
        {
            _companyDataAppService = companyDataAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}