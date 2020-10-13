using AbpCMS.Companies;

namespace AbpCMS.CompanyDatas
{
    public class CompanyDataWithNavigationProperties
    {
        public CompanyData CompanyData { get; set; }

        public Company Company { get; set; }
        
    }
}