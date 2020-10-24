using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpCMS.Companies;
using AbpCMS.CompanyDatas;
using AbpCMS.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpCMS.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : AbpController
    {
        private readonly ICompanyAppService _companyAppService;

        public HomeController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(IList<IFormFile> files)
        {
            if (files == null || !files.Any())
            {
                return NoContent();
            }

            foreach (var file in files)
            {
                await CreateCompanyData(file);
            }
            return NoContent();
        }


        private async Task CreateCompanyData(IFormFile file)
        {
            var readAllLines = file.ReadAsList();
            
        }

        public async Task<IActionResult> Detail(Guid? id)
        {
            return NoContent();
        }
    }
}
