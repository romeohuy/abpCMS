using System;
using System.ComponentModel.DataAnnotations;

namespace AbpCMS.Cagegories
{
    public class CagegoryCreateDto
    {
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}