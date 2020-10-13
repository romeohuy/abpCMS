using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AbpCMS.Permissions;
using AbpCMS.Cagegories;

namespace AbpCMS.Cagegories
{

    [Authorize(AbpCMSPermissions.Cagegories.Default)]
    public class CagegoryAppService : ApplicationService, ICagegoryAppService
    {
        private readonly ICagegoryRepository _cagegoryRepository;

        public CagegoryAppService(ICagegoryRepository cagegoryRepository)
        {
            _cagegoryRepository = cagegoryRepository;
        }

        public virtual async Task<PagedResultDto<CagegoryDto>> GetListAsync(GetCagegoriesInput input)
        {
            var totalCount = await _cagegoryRepository.GetCountAsync(input.FilterText, input.Name, input.IsActive);
            var items = await _cagegoryRepository.GetListAsync(input.FilterText, input.Name, input.IsActive, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CagegoryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Cagegory>, List<CagegoryDto>>(items)
            };
        }

        public virtual async Task<CagegoryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Cagegory, CagegoryDto>(await _cagegoryRepository.GetAsync(id));
        }

        [Authorize(AbpCMSPermissions.Cagegories.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _cagegoryRepository.DeleteAsync(id);
        }

        [Authorize(AbpCMSPermissions.Cagegories.Create)]
        public virtual async Task<CagegoryDto> CreateAsync(CagegoryCreateDto input)
        {
            var cagegory = ObjectMapper.Map<CagegoryCreateDto, Cagegory>(input);

            cagegory = await _cagegoryRepository.InsertAsync(cagegory, autoSave: true);
            return ObjectMapper.Map<Cagegory, CagegoryDto>(cagegory);
        }

        [Authorize(AbpCMSPermissions.Cagegories.Edit)]
        public virtual async Task<CagegoryDto> UpdateAsync(Guid id, CagegoryUpdateDto input)
        {
            var cagegory = await _cagegoryRepository.GetAsync(id);
            ObjectMapper.Map(input, cagegory);
            cagegory = await _cagegoryRepository.UpdateAsync(cagegory);
            return ObjectMapper.Map<Cagegory, CagegoryDto>(cagegory);
        }
    }
}