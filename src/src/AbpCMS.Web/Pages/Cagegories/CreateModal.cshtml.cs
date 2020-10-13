using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AbpCMS.Cagegories;

namespace AbpCMS.Web.Pages.Cagegories
{
    public class CreateModalModel : AbpCMSPageModel
    {
        [BindProperty]
        public CagegoryCreateDto Cagegory { get; set; }

        private readonly ICagegoryAppService _cagegoryAppService;

        public CreateModalModel(ICagegoryAppService cagegoryAppService)
        {
            _cagegoryAppService = cagegoryAppService;
        }

        public async Task OnGetAsync()
        {
            Cagegory = new CagegoryCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _cagegoryAppService.CreateAsync(Cagegory);
            return NoContent();
        }
    }
}