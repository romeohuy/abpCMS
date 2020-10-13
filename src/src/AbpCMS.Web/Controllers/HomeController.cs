using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpCMS.Companies;
using AbpCMS.CompanyDatas;
using AbpCMS.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpCMS.Web.Controllers
{
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

        public async Task<IActionResult> UploadProductFullPrint(IList<IFormFile> files)
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
            var countCp = readAllLines.Count / 25;
            var listCompanyData = new List<CompanyDataCreateDto>();
            for (int i = 0; i < countCp; i++)
            {
                for (int j = i * 25; j < (i + 1) * 25; j++)
                {
                    //listCompanyData.Add(new CompanyDataCreateDto()
                    //{
                    //    Percent = readAllLines[j].Split('|')[0],
                    //    CN = readAllLines[j].Split('|')[1],
                    //    TN = readAllLines[j].Split('|')[2],

                    //});
                }
            }
        } 
    }
}
