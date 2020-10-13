using AbpCMS.CompanyDatas;
using AbpCMS.Companies;
using System;
using AbpCMS.Shared;
using Volo.Abp.AutoMapper;
using AbpCMS.Cagegories;
using AutoMapper;

namespace AbpCMS
{
    public class AbpCMSApplicationAutoMapperProfile : Profile
    {
        public AbpCMSApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<CagegoryCreateDto, Cagegory>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<CagegoryUpdateDto, Cagegory>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Cagegory, CagegoryDto>();

            CreateMap<CompanyCreateDto, Company>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<CompanyUpdateDto, Company>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyWithNavigationProperties, CompanyWithNavigationPropertiesDto>();
            CreateMap<Cagegory, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CompanyDataCreateDto, CompanyData>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<CompanyDataUpdateDto, CompanyData>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<CompanyData, CompanyDataDto>();
            CreateMap<CompanyDataWithNavigationProperties, CompanyDataWithNavigationPropertiesDto>();
            CreateMap<Company, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
        }
    }
}