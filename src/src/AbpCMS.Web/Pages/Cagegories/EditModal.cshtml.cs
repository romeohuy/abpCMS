using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using AbpCMS.Cagegories;

namespace AbpCMS.Web.Pages.Cagegories
{
    public class EditModalModel : AbpCMSPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CagegoryUpdateDto Cagegory { get; set; }

        private readonly ICagegoryAppService _cagegoryAppService;

        public EditModalModel(ICagegoryAppService cagegoryAppService)
        {
            _cagegoryAppService = cagegoryAppService;
        }

        public async Task OnGetAsync()
        {
            var cagegory = await _cagegoryAppService.GetAsync(Id);
            Cagegory = ObjectMapper.Map<CagegoryDto, CagegoryUpdateDto>(cagegory);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _cagegoryAppService.UpdateAsync(Id, Cagegory);
            return NoContent();
        }
    }
}