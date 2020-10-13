using Volo.Abp.Application.Dtos;

namespace AbpCMS.Shared
{
    public class LookupRequestDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}