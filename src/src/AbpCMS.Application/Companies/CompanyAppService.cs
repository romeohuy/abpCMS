using AbpCMS.Shared;
using AbpCMS.Cagegories;
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
using AbpCMS.Companies;

namespace AbpCMS.Companies
{

    [Authorize(AbpCMSPermissions.Companies.Default)]
    public class CompanyAppService : ApplicationService, ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IRepository<Cagegory, Guid> _cagegoryRepository;

        public CompanyAppService(ICompanyRepository companyRepository, IRepository<Cagegory, Guid> cagegoryRepository)
        {
            _companyRepository = companyRepository; _cagegoryRepository = cagegoryRepository;
        }

        public virtual async Task<PagedResultDto<CompanyWithNavigationPropertiesDto>> GetListAsync(GetCompaniesInput input)
        {
            var totalCount = await _companyRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.IsActive, input.CagegoryId);
            var items = await _companyRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Code, input.Name, input.IsActive, input.CagegoryId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyWithNavigationProperties>, List<CompanyWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<CompanyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyWithNavigationProperties, CompanyWithNavigationPropertiesDto>
                (await _companyRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<CompanyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Company, CompanyDto>(await _companyRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid?>>> GetCagegoryLookupAsync(LookupRequestDto input)
        {
            var query = _cagegoryRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.Name != null && x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Cagegory>();

            var totalCount = query.Count();

            return new PagedResultDto<LookupDto<Guid?>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Cagegory>, List<LookupDto<Guid?>>>(lookupData)
            };
        }

        [Authorize(AbpCMSPermissions.Companies.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        [Authorize(AbpCMSPermissions.Companies.Create)]
        public virtual async Task<CompanyDto> CreateAsync(CompanyCreateDto input)
        {
            var company = ObjectMapper.Map<CompanyCreateDto, Company>(input);

            company = await _companyRepository.InsertAsync(company, autoSave: true);
            return ObjectMapper.Map<Company, CompanyDto>(company);
        }

        [Authorize(AbpCMSPermissions.Companies.Edit)]
        public virtual async Task<CompanyDto> UpdateAsync(Guid id, CompanyUpdateDto input)
        {
            var company = await _companyRepository.GetAsync(id);
            ObjectMapper.Map(input, company);
            company = await _companyRepository.UpdateAsync(company);
            return ObjectMapper.Map<Company, CompanyDto>(company);
        }
    }
}