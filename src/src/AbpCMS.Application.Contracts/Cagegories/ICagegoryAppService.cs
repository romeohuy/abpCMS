using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpCMS.Cagegories
{
    public interface ICagegoryAppService : IApplicationService
    {
        Task<PagedResultDto<CagegoryDto>> GetListAsync(GetCagegoriesInput input);

        Task<CagegoryDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CagegoryDto> CreateAsync(CagegoryCreateDto input);

        Task<CagegoryDto> UpdateAsync(Guid id, CagegoryUpdateDto input);
    }
}