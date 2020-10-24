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

namespace AbpCMS.CompanyDatas
{
    public class EfCoreCompanyDataRepository : EfCoreRepository<AbpCMSDbContext, CompanyData, Guid>, ICompanyDataRepository
    {
        public EfCoreCompanyDataRepository(IDbContextProvider<AbpCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<CompanyDataWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetQueryForNavigationProperties()
                .FirstOrDefaultAsync(e => e.CompanyData.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<CompanyDataWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string title = null,
            string shortDescription = null,
            string content = null,
            Guid? companyId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, title, shortDescription, content, companyId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyDataConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual IQueryable<CompanyDataWithNavigationProperties> GetQueryForNavigationProperties()
        {
            return from companyData in DbSet
                   join company in DbContext.Companies on companyData.CompanyId equals company.Id into companies
                   from company in companies.DefaultIfEmpty()

                   select new CompanyDataWithNavigationProperties
                   {
                       CompanyData = companyData,
                       Company = company
                   };
        }

        protected virtual IQueryable<CompanyDataWithNavigationProperties> ApplyFilter(
            IQueryable<CompanyDataWithNavigationProperties> query,
            string filterText,
            string title = null,
            string shortDescription = null,
            string content = null,
            Guid? companyId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CompanyData.Title.Contains(filterText) || e.CompanyData.ShortDescription.Contains(filterText) || e.CompanyData.Content.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(title), e => e.CompanyData.Title.Contains(title))
                    .WhereIf(!string.IsNullOrWhiteSpace(shortDescription), e => e.CompanyData.ShortDescription.Contains(shortDescription))
                    .WhereIf(!string.IsNullOrWhiteSpace(content), e => e.CompanyData.Content.Contains(content))
                    .WhereIf(companyId != null && companyId != Guid.Empty, e => e.Company != null && e.Company.Id == companyId);
        }

        public async Task<List<CompanyData>> GetListAsync(
            string filterText = null,
            string title = null,
            string shortDescription = null,
            string content = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, title, shortDescription, content);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyDataConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string title = null,
            string shortDescription = null,
            string content = null,
            Guid? companyId = null,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, title, shortDescription, content, companyId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyData> ApplyFilter(
            IQueryable<CompanyData> query,
            string filterText,
            string title = null,
            string shortDescription = null,
            string content = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Title.Contains(filterText) || e.ShortDescription.Contains(filterText) || e.Content.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(title), e => e.Title.Contains(title))
                    .WhereIf(!string.IsNullOrWhiteSpace(shortDescription), e => e.ShortDescription.Contains(shortDescription))
                    .WhereIf(!string.IsNullOrWhiteSpace(content), e => e.Content.Contains(content));
        }
    }
}