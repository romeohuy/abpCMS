using AbpCMS.Cagegories;

using System;
using Volo.Abp.Application.Dtos;

namespace AbpCMS.Companies
{
    public class CompanyWithNavigationPropertiesDto
    {
        public CompanyDto Company { get; set; }

        public CagegoryDto Cagegory { get; set; }

    }
}