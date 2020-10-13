using AbpCMS.Cagegories;

namespace AbpCMS.Companies
{
    public class CompanyWithNavigationProperties
    {
        public Company Company { get; set; }

        public Cagegory Cagegory { get; set; }
        
    }
}