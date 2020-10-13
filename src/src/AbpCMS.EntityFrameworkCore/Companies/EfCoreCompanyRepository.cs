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

namespace AbpCMS.Companies
{
    public class EfCoreCompanyRepository : EfCoreRepository<AbpCMSDbContext, Company, Guid>, ICompanyRepository
    {
        public EfCoreCompanyRepository(IDbContextProvider<AbpCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<CompanyWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetQueryForNavigationProperties()
                .FirstOrDefaultAsync(e => e.Company.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<CompanyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string code = null,
            string name = null,
            bool? isActive = null,
            Guid? cagegoryId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, code, name, isActive, cagegoryId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual IQueryable<CompanyWithNavigationProperties> GetQueryForNavigationProperties()
        {
            return from company in DbSet
                   join cagegory in DbContext.Cagegories on company.CagegoryId equals cagegory.Id into cagegories
                   from cagegory in cagegories.DefaultIfEmpty()

                   select new CompanyWithNavigationProperties
                   {
                       Company = company,
                       Cagegory = cagegory
                   };
        }

        protected virtual IQueryable<CompanyWithNavigationProperties> ApplyFilter(
            IQueryable<CompanyWithNavigationProperties> query,
            string filterText,
            string code = null,
            string name = null,
            bool? isActive = null,
            Guid? cagegoryId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Company.Code.Contains(filterText) || e.Company.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Company.Code.Contains(code))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Company.Name.Contains(name))
                    .WhereIf(isActive.HasValue, e => e.Company.IsActive == isActive)
                    .WhereIf(cagegoryId != null && cagegoryId != Guid.Empty, e => e.Cagegory != null && e.Cagegory.Id == cagegoryId);
        }

        public async Task<List<Company>> GetListAsync(
            string filterText = null,
            string code = null,
            string name = null,
            bool? isActive = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, code, name, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string code = null,
            string name = null,
            bool? isActive = null,
            Guid? cagegoryId = null,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, code, name, isActive, cagegoryId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Company> ApplyFilter(
            IQueryable<Company> query,
            string filterText,
            string code = null,
            string name = null,
            bool? isActive = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.Contains(filterText) || e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }
    }
}