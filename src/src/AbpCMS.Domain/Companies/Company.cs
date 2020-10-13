using AbpCMS.Cagegories;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpCMS.Companies
{
    public class Company : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Code { get; set; }

        [CanBeNull]
        public virtual string Name { get; set; }

        public virtual bool IsActive { get; set; }
        public Guid? CagegoryId { get; set; }

        public Company()
        {

        }

        public Company(Guid id, string code, string name, bool isActive)
        {
            Id = id;
            Check.NotNull(code, nameof(code));
            Code = code;
            Name = name;
            IsActive = isActive;
        }
    }
}