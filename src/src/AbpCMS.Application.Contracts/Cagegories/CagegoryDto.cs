using System;
using Volo.Abp.Application.Dtos;

namespace AbpCMS.Cagegories
{
    public class CagegoryDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}