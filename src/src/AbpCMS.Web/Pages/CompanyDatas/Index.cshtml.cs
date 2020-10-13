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
        public string PercentFilter { get; set; }
        public string CNFilter { get; set; }
        public string TNFilter { get; set; }
        public string GiaFilter { get; set; }
        public string GiaTheoPhanTramFilter { get; set; }
        public string BienDongGiaFilter { get; set; }
        public string BienDongCaoThapFilter { get; set; }
        public string LuuYFilter { get; set; }
        public string KLFilter { get; set; }
        public string KLPhanTramFilter { get; set; }
        public string NNFilter { get; set; }
        public string GiaTriNNFilter { get; set; }
        public string NNMuaCongBanFilter { get; set; }
        public string NNMuaTruBanFilter { get; set; }
        public string SucManhFilter { get; set; }
        public string DiemGiaFilter { get; set; }
        public string LinkThamKhaoFilter { get; set; }
        public DateTime? CreatedDateFilterMin { get; set; }

        public DateTime? CreatedDateFilterMax { get; set; }

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