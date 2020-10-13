using AbpCMS.CompanyDatas;
using AbpCMS.Companies;
using AbpCMS.Cagegories;
using AutoMapper;

namespace AbpCMS.Web
{
    public class AbpCMSWebAutoMapperProfile : Profile
    {
        public AbpCMSWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            CreateMap<CagegoryDto, CagegoryUpdateDto>();

            CreateMap<CompanyDto, CompanyUpdateDto>();

            CreateMap<CompanyDataDto, CompanyDataUpdateDto>();
        }
    }
}