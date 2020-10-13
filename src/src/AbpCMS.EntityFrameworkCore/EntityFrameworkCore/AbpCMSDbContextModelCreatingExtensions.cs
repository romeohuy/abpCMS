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
                b.Property(x => x.Percent).HasColumnName(nameof(CompanyData.Percent));
                b.Property(x => x.CN).HasColumnName(nameof(CompanyData.CN));
                b.Property(x => x.TN).HasColumnName(nameof(CompanyData.TN));
                b.Property(x => x.Gia).HasColumnName(nameof(CompanyData.Gia));
                b.Property(x => x.GiaTheoPhanTram).HasColumnName(nameof(CompanyData.GiaTheoPhanTram));
                b.Property(x => x.BienDongGia).HasColumnName(nameof(CompanyData.BienDongGia));
                b.Property(x => x.BienDongCaoThap).HasColumnName(nameof(CompanyData.BienDongCaoThap));
                b.Property(x => x.LuuY).HasColumnName(nameof(CompanyData.LuuY));
                b.Property(x => x.KL).HasColumnName(nameof(CompanyData.KL));
                b.Property(x => x.KLPhanTram).HasColumnName(nameof(CompanyData.KLPhanTram));
                b.Property(x => x.NN).HasColumnName(nameof(CompanyData.NN));
                b.Property(x => x.GiaTriNN).HasColumnName(nameof(CompanyData.GiaTriNN));
                b.Property(x => x.NNMuaCongBan).HasColumnName(nameof(CompanyData.NNMuaCongBan));
                b.Property(x => x.NNMuaTruBan).HasColumnName(nameof(CompanyData.NNMuaTruBan));
                b.Property(x => x.SucManh).HasColumnName(nameof(CompanyData.SucManh));
                b.Property(x => x.DiemGia).HasColumnName(nameof(CompanyData.DiemGia));
                b.Property(x => x.LinkThamKhao).HasColumnName(nameof(CompanyData.LinkThamKhao));
                b.Property(x => x.CreatedDate).HasColumnName(nameof(CompanyData.CreatedDate));
            });
        }
    }
}