using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpCMS.EntityFrameworkCore
{
    public static class AbpCMSDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpCMS(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpCMSConsts.DbTablePrefix + "YourEntities", AbpCMSConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}