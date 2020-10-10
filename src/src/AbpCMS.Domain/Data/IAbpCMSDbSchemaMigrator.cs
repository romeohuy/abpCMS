using System.Threading.Tasks;

namespace AbpCMS.Data
{
    public interface IAbpCMSDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}