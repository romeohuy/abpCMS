using AbpCMS.Companies;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpCMS.CompanyDatas
{
    public class CompanyData : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Title { get; set; }

        [CanBeNull]
        public virtual string ShortDescription { get; set; }

        [CanBeNull]
        public virtual string Content { get; set; }
        public Guid? CompanyId { get; set; }

        public CompanyData()
        {

        }

        public CompanyData(Guid id, string title, string shortDescription, string content)
        {
            Id = id;
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
        }
    }
}