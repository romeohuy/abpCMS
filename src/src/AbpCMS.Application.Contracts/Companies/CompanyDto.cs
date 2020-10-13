using System;
using Volo.Abp.Application.Dtos;

namespace AbpCMS.Companies
{
    public class CompanyDto : FullAuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid? CagegoryId { get; set; }
    }
}