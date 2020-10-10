using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpCMS.Pages
{
    public class Index_Tests : AbpCMSWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
