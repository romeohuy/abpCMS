using System;
using System.ComponentModel.DataAnnotations;

namespace AbpCMS.CompanyDatas
{
    public class CompanyDataCreateDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public Guid? CompanyId { get; set; }
    }
}