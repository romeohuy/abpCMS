using AbpCMS.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpCMS.Companies
{
    public interface ICompanyAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyWithNavigationPropertiesDto>> GetListAsync(GetCompaniesInput input);

        Task<CompanyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<CompanyDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid?>>> GetCagegoryLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<CompanyDto> CreateAsync(CompanyCreateDto input);

        Task<CompanyDto> UpdateAsync(Guid id, CompanyUpdateDto input);
    }
}