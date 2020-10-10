using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpCMS.Data
{
    /* This is used if database provider does't define
     * IAbpCMSDbSchemaMigrator implementation.
     */
    public class NullAbpCMSDbSchemaMigrator : IAbpCMSDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}