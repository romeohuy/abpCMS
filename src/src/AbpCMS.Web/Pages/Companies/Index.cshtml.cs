using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using AbpCMS.Companies;
using AbpCMS.Shared;

namespace AbpCMS.Web.Pages.Companies
{
    public class IndexModel : AbpPageModel
    {
        public string CodeFilter { get; set; }
        public string NameFilter { get; set; }
        [SelectItems(nameof(IsActiveBoolFilterItems))]
        public string IsActiveFilter { get; set; }

        public List<SelectListItem> IsActiveBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        [SelectItems(nameof(CagegoryLookupList))]
        public Guid? CagegoryIdFilter { get; set; }
        public List<SelectListItem> CagegoryLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("", Guid.Empty.ToString())
        };

        private readonly ICompanyAppService _companyAppService;

        public IndexModel(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public async Task OnGetAsync()
        {
            CagegoryLookupList.AddRange(
        (await _companyAppService.GetCagegoryLookupAsync(new LookupRequestDto { MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount })).Items
        .Select(t => new SelectListItem(t.DisplayName, t.Id.ToString()))
        .ToList());

            await Task.CompletedTask;
        }
    }
}