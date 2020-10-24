using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpCMS.CompanyDatas
{
    public interface ICompanyDataRepository : IRepository<CompanyData, Guid>
    {
        Task<CompanyDataWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<CompanyDataWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string title = null,
            string shortDescription = null,
            string content = null,
            Guid? companyId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<CompanyData>> GetListAsync(
                    string filterText = null,
                    string title = null,
                    string shortDescription = null,
                    string content = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string title = null,
            string shortDescription = null,
            string content = null,
            Guid? companyId = null,
            CancellationToken cancellationToken = default);
    }
}