using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpCMS.Companies
{
    public interface ICompanyRepository : IRepository<Company, Guid>
    {
        Task<CompanyWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<CompanyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string code = null,
            string name = null,
            bool? isActive = null,
            Guid? cagegoryId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Company>> GetListAsync(
                    string filterText = null,
                    string code = null,
                    string name = null,
                    bool? isActive = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string code = null,
            string name = null,
            bool? isActive = null,
            Guid? cagegoryId = null,
            CancellationToken cancellationToken = default);
    }
}