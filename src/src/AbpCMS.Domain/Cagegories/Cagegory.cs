using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpCMS.Cagegories
{
    public class Cagegory : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        public virtual bool IsActive { get; set; }

        public Cagegory()
        {

        }

        public Cagegory(Guid id, string name, bool isActive)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Name = name;
            IsActive = isActive;
        }
    }
}