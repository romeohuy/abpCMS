using AbpCMS.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AbpCMS.CompanyDatas;

namespace AbpCMS.Web.Pages.CompanyDatas
{
    public class CreateModalModel : AbpCMSPageModel
    {
        [BindProperty]
        public CompanyDataCreateDto CompanyData { get; set; }

        private readonly ICompanyDataAppService _companyDataAppService;

        public CreateModalModel(ICompanyDataAppService companyDataAppService)
        {
            _companyDataAppService = companyDataAppService;
        }

        public async Task OnGetAsync()
        {
            CompanyData = new CompanyDataCreateDto();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _companyDataAppService.CreateAsync(CompanyData);
            return NoContent();
        }
    }
}