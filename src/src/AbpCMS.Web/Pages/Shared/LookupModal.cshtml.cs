using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbpCMS.Web.Pages.Shared
{
    public class LookupModal : AbpCMSPageModel
    {
        public string CurrentId { get; set; }
        public string CurrentDisplayName { get; set; }

        public async Task OnGetAsync(string currentId, string currentDisplayName)
        {
            CurrentId = currentId;
            CurrentDisplayName = currentDisplayName;
        }
    }
}