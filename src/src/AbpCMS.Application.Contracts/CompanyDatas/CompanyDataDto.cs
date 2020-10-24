using System;
using Volo.Abp.Application.Dtos;

namespace AbpCMS.CompanyDatas
{
    public class CompanyDataDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public Guid? CompanyId { get; set; }
    }
}