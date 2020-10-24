using AbpCMS.CompanyDatas;
using AbpCMS.Companies;
using Volo.Abp.EntityFrameworkCore.Modeling;
using AbpCMS.Cagegories;
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

            builder.Entity<Cagegory>(b =>
            {
                b.ToTable(AbpCMSConsts.DbTablePrefix + "Cagegories", AbpCMSConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).HasColumnName(nameof(Cagegory.Name)).IsRequired();
                b.Property(x => x.IsActive).HasColumnName(nameof(Cagegory.IsActive));
            });

            builder.Entity<Company>(b =>
            {
                b.ToTable(AbpCMSConsts.DbTablePrefix + "Companies", AbpCMSConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(Company.Code)).IsRequired();
                b.Property(x => x.Name).HasColumnName(nameof(Company.Name));
                b.Property(x => x.IsActive).HasColumnName(nameof(Company.IsActive));
            });

            builder.Entity<CompanyData>(b =>
            {
                b.ToTable(AbpCMSConsts.DbTablePrefix + "CompanyDatas", AbpCMSConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Title).HasColumnName(nameof(CompanyData.Title));
                b.Property(x => x.ShortDescription).HasColumnName(nameof(CompanyData.ShortDescription));
                b.Property(x => x.Content).HasColumnName(nameof(CompanyData.Content));
            });
        }
    }
}