using Volo.Abp.Application.Dtos;
using System;

namespace AbpCMS.CompanyDatas
{
    public class GetCompanyDatasInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public Guid? CompanyId { get; set; }

        public GetCompanyDatasInput()
        {

        }
    }
}