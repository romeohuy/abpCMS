using AbpCMS.Shared;
using AbpCMS.Companies;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using AbpCMS.CompanyDatas;

namespace AbpCMS.Web.Pages.CompanyDatas
{
    public class EditModalModel : AbpCMSPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CompanyDataUpdateDto CompanyData { get; set; }

        public CompanyDto Company { get; set; }

        private readonly ICompanyDataAppService _companyDataAppService;

        public EditModalModel(ICompanyDataAppService companyDataAppService)
        {
            _companyDataAppService = companyDataAppService;
        }

        public async Task OnGetAsync()
        {
            var companyDataWithNavigationPropertiesDto = await _companyDataAppService.GetWithNavigationPropertiesAsync(Id);
            CompanyData = ObjectMapper.Map<CompanyDataDto, CompanyDataUpdateDto>(companyDataWithNavigationPropertiesDto.CompanyData);

            Company = companyDataWithNavigationPropertiesDto.Company;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _companyDataAppService.UpdateAsync(Id, CompanyData);
            return NoContent();
        }
    }
}