using AbpCMS.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpCMS.CompanyDatas
{
    public interface ICompanyDataAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyDataWithNavigationPropertiesDto>> GetListAsync(GetCompanyDatasInput input);

        Task<CompanyDataWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<CompanyDataDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid?>>> GetCompanyLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<CompanyDataDto> CreateAsync(CompanyDataCreateDto input);

        Task<CompanyDataDto> UpdateAsync(Guid id, CompanyDataUpdateDto input);
    }
}