using System;
using System.ComponentModel.DataAnnotations;

namespace AbpCMS.Companies
{
    public class CompanyUpdateDto
    {
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid? CagegoryId { get; set; }
    }
}