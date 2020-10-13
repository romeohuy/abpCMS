using AbpCMS.Shared;
using AbpCMS.Companies;
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
using AbpCMS.CompanyDatas;

namespace AbpCMS.CompanyDatas
{

    [Authorize(AbpCMSPermissions.CompanyDatas.Default)]
    public class CompanyDataAppService : ApplicationService, ICompanyDataAppService
    {
        private readonly ICompanyDataRepository _companyDataRepository;
        private readonly IRepository<Company, Guid> _companyRepository;

        public CompanyDataAppService(ICompanyDataRepository companyDataRepository, IRepository<Company, Guid> companyRepository)
        {
            _companyDataRepository = companyDataRepository; _companyRepository = companyRepository;
        }

        public virtual async Task<PagedResultDto<CompanyDataWithNavigationPropertiesDto>> GetListAsync(GetCompanyDatasInput input)
        {
            var totalCount = await _companyDataRepository.GetCountAsync(input.FilterText, input.Percent, input.CN, input.TN, input.Gia, input.GiaTheoPhanTram, input.BienDongGia, input.BienDongCaoThap, input.LuuY, input.KL, input.KLPhanTram, input.NN, input.GiaTriNN, input.NNMuaCongBan, input.NNMuaTruBan, input.SucManh, input.DiemGia, input.LinkThamKhao, input.CreatedDateMin, input.CreatedDateMax, input.CompanyId);
            var items = await _companyDataRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Percent, input.CN, input.TN, input.Gia, input.GiaTheoPhanTram, input.BienDongGia, input.BienDongCaoThap, input.LuuY, input.KL, input.KLPhanTram, input.NN, input.GiaTriNN, input.NNMuaCongBan, input.NNMuaTruBan, input.SucManh, input.DiemGia, input.LinkThamKhao, input.CreatedDateMin, input.CreatedDateMax, input.CompanyId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyDataWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyDataWithNavigationProperties>, List<CompanyDataWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<CompanyDataWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyDataWithNavigationProperties, CompanyDataWithNavigationPropertiesDto>
                (await _companyDataRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<CompanyDataDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyData, CompanyDataDto>(await _companyDataRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid?>>> GetCompanyLookupAsync(LookupRequestDto input)
        {
            var query = _companyRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.Name != null && x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Company>();

            var totalCount = query.Count();

            return new PagedResultDto<LookupDto<Guid?>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Company>, List<LookupDto<Guid?>>>(lookupData)
            };
        }

        [Authorize(AbpCMSPermissions.CompanyDatas.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyDataRepository.DeleteAsync(id);
        }

        [Authorize(AbpCMSPermissions.CompanyDatas.Create)]
        public virtual async Task<CompanyDataDto> CreateAsync(CompanyDataCreateDto input)
        {
            var companyData = ObjectMapper.Map<CompanyDataCreateDto, CompanyData>(input);

            companyData = await _companyDataRepository.InsertAsync(companyData, autoSave: true);
            return ObjectMapper.Map<CompanyData, CompanyDataDto>(companyData);
        }

        [Authorize(AbpCMSPermissions.CompanyDatas.Edit)]
        public virtual async Task<CompanyDataDto> UpdateAsync(Guid id, CompanyDataUpdateDto input)
        {
            var companyData = await _companyDataRepository.GetAsync(id);
            ObjectMapper.Map(input, companyData);
            companyData = await _companyDataRepository.UpdateAsync(companyData);
            return ObjectMapper.Map<CompanyData, CompanyDataDto>(companyData);
        }
    }
}