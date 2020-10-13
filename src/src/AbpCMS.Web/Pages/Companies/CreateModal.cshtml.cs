using AbpCMS.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AbpCMS.Companies;

namespace AbpCMS.Web.Pages.Companies
{
    public class CreateModalModel : AbpCMSPageModel
    {
        [BindProperty]
        public CompanyCreateDto Company { get; set; }

        public List<SelectListItem> CagegoryLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("", Guid.Empty.ToString())
        };

        private readonly ICompanyAppService _companyAppService;

        public CreateModalModel(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public async Task OnGetAsync()
        {
            Company = new CompanyCreateDto();
            CagegoryLookupList.AddRange(
                            (await _companyAppService.GetCagegoryLookupAsync(new LookupRequestDto { MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount })).Items
                            .Select(t => new SelectListItem(t.DisplayName, t.Id.ToString()))
                            .ToList());

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _companyAppService.CreateAsync(Company);
            return NoContent();
        }
    }
}