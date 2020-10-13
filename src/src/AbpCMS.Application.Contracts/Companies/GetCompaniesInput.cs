using Volo.Abp.Application.Dtos;
using System;

namespace AbpCMS.Companies
{
    public class GetCompaniesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CagegoryId { get; set; }

        public GetCompaniesInput()
        {

        }
    }
}