using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using AbpCMS.EntityFrameworkCore;

namespace AbpCMS.Cagegories
{
    public class EfCoreCagegoryRepository : EfCoreRepository<AbpCMSDbContext, Cagegory, Guid>, ICagegoryRepository
    {
        public EfCoreCagegoryRepository(IDbContextProvider<AbpCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Cagegory>> GetListAsync(
            string filterText = null,
            string name = null,
            bool? isActive = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CagegoryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name, isActive);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Cagegory> ApplyFilter(
            IQueryable<Cagegory> query,
            string filterText,
            string name = null,
            bool? isActive = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }
    }
}