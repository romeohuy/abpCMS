using Volo.Abp.Application.Dtos;
using System;

namespace AbpCMS.Cagegories
{
    public class GetCagegoriesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public GetCagegoriesInput()
        {

        }
    }
}