using AbpCMS.Companies;

using System;
using Volo.Abp.Application.Dtos;

namespace AbpCMS.CompanyDatas
{
    public class CompanyDataWithNavigationPropertiesDto
    {
        public CompanyDataDto CompanyData { get; set; }

        public CompanyDto Company { get; set; }

    }
}