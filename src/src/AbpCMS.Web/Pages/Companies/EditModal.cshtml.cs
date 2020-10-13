using AbpCMS.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using AbpCMS.Companies;

namespace AbpCMS.Web.Pages.Companies
{
    public class EditModalModel : AbpCMSPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CompanyUpdateDto Company { get; set; }

        public List<SelectListItem> CagegoryLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("", Guid.Empty.ToString())
        };

        private readonly ICompanyAppService _companyAppService;

        public EditModalModel(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public async Task OnGetAsync()
        {
            var companyWithNavigationPropertiesDto = await _companyAppService.GetWithNavigationPropertiesAsync(Id);
            Company = ObjectMapper.Map<CompanyDto, CompanyUpdateDto>(companyWithNavigationPropertiesDto.Company);

            CagegoryLookupList.AddRange(
                            (await _companyAppService.GetCagegoryLookupAsync(new LookupRequestDto { MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount })).Items
                            .Select(t => new SelectListItem(t.DisplayName, t.Id.ToString()))
                            .ToList());

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _companyAppService.UpdateAsync(Id, Company);
            return NoContent();
        }
    }
}