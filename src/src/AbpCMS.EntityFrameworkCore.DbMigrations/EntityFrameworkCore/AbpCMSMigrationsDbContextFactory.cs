using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpCMS.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class AbpCMSMigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpCMSMigrationsDbContext>
    {
        public AbpCMSMigrationsDbContext CreateDbContext(string[] args)
        {
            AbpCMSEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpCMSMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new AbpCMSMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpCMS.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
