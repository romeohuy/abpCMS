using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using AbpCMS.EntityFrameworkCore;

namespace AbpCMS.CompanyDatas
{
    public class EfCoreCompanyDataRepository : EfCoreRepository<AbpCMSDbContext, CompanyData, Guid>, ICompanyDataRepository
    {
        public EfCoreCompanyDataRepository(IDbContextProvider<AbpCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<CompanyDataWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetQueryForNavigationProperties()
                .FirstOrDefaultAsync(e => e.CompanyData.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<CompanyDataWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string percent = null,
            string cN = null,
            string tN = null,
            string gia = null,
            string giaTheoPhanTram = null,
            string bienDongGia = null,
            string bienDongCaoThap = null,
            string luuY = null,
            string kL = null,
            string kLPhanTram = null,
            string nN = null,
            string giaTriNN = null,
            string nNMuaCongBan = null,
            string nNMuaTruBan = null,
            string sucManh = null,
            string diemGia = null,
            string linkThamKhao = null,
            DateTime? createdDateMin = null,
            DateTime? createdDateMax = null,
            Guid? companyId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, percent, cN, tN, gia, giaTheoPhanTram, bienDongGia, bienDongCaoThap, luuY, kL, kLPhanTram, nN, giaTriNN, nNMuaCongBan, nNMuaTruBan, sucManh, diemGia, linkThamKhao, createdDateMin, createdDateMax, companyId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyDataConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual IQueryable<CompanyDataWithNavigationProperties> GetQueryForNavigationProperties()
        {
            return from companyData in DbSet
                   join company in DbContext.Companies on companyData.CompanyId equals company.Id into companies
                   from company in companies.DefaultIfEmpty()

                   select new CompanyDataWithNavigationProperties
                   {
                       CompanyData = companyData,
                       Company = company
                   };
        }

        protected virtual IQueryable<CompanyDataWithNavigationProperties> ApplyFilter(
            IQueryable<CompanyDataWithNavigationProperties> query,
            string filterText,
            string percent = null,
            string cN = null,
            string tN = null,
            string gia = null,
            string giaTheoPhanTram = null,
            string bienDongGia = null,
            string bienDongCaoThap = null,
            string luuY = null,
            string kL = null,
            string kLPhanTram = null,
            string nN = null,
            string giaTriNN = null,
            string nNMuaCongBan = null,
            string nNMuaTruBan = null,
            string sucManh = null,
            string diemGia = null,
            string linkThamKhao = null,
            DateTime? createdDateMin = null,
            DateTime? createdDateMax = null,
            Guid? companyId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CompanyData.Percent.Contains(filterText) || e.CompanyData.CN.Contains(filterText) || e.CompanyData.TN.Contains(filterText) || e.CompanyData.Gia.Contains(filterText) || e.CompanyData.GiaTheoPhanTram.Contains(filterText) || e.CompanyData.BienDongGia.Contains(filterText) || e.CompanyData.BienDongCaoThap.Contains(filterText) || e.CompanyData.LuuY.Contains(filterText) || e.CompanyData.KL.Contains(filterText) || e.CompanyData.KLPhanTram.Contains(filterText) || e.CompanyData.NN.Contains(filterText) || e.CompanyData.GiaTriNN.Contains(filterText) || e.CompanyData.NNMuaCongBan.Contains(filterText) || e.CompanyData.NNMuaTruBan.Contains(filterText) || e.CompanyData.SucManh.Contains(filterText) || e.CompanyData.DiemGia.Contains(filterText) || e.CompanyData.LinkThamKhao.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(percent), e => e.CompanyData.Percent.Contains(percent))
                    .WhereIf(!string.IsNullOrWhiteSpace(cN), e => e.CompanyData.CN.Contains(cN))
                    .WhereIf(!string.IsNullOrWhiteSpace(tN), e => e.CompanyData.TN.Contains(tN))
                    .WhereIf(!string.IsNullOrWhiteSpace(gia), e => e.CompanyData.Gia.Contains(gia))
                    .WhereIf(!string.IsNullOrWhiteSpace(giaTheoPhanTram), e => e.CompanyData.GiaTheoPhanTram.Contains(giaTheoPhanTram))
                    .WhereIf(!string.IsNullOrWhiteSpace(bienDongGia), e => e.CompanyData.BienDongGia.Contains(bienDongGia))
                    .WhereIf(!string.IsNullOrWhiteSpace(bienDongCaoThap), e => e.CompanyData.BienDongCaoThap.Contains(bienDongCaoThap))
                    .WhereIf(!string.IsNullOrWhiteSpace(luuY), e => e.CompanyData.LuuY.Contains(luuY))
                    .WhereIf(!string.IsNullOrWhiteSpace(kL), e => e.CompanyData.KL.Contains(kL))
                    .WhereIf(!string.IsNullOrWhiteSpace(kLPhanTram), e => e.CompanyData.KLPhanTram.Contains(kLPhanTram))
                    .WhereIf(!string.IsNullOrWhiteSpace(nN), e => e.CompanyData.NN.Contains(nN))
                    .WhereIf(!string.IsNullOrWhiteSpace(giaTriNN), e => e.CompanyData.GiaTriNN.Contains(giaTriNN))
                    .WhereIf(!string.IsNullOrWhiteSpace(nNMuaCongBan), e => e.CompanyData.NNMuaCongBan.Contains(nNMuaCongBan))
                    .WhereIf(!string.IsNullOrWhiteSpace(nNMuaTruBan), e => e.CompanyData.NNMuaTruBan.Contains(nNMuaTruBan))
                    .WhereIf(!string.IsNullOrWhiteSpace(sucManh), e => e.CompanyData.SucManh.Contains(sucManh))
                    .WhereIf(!string.IsNullOrWhiteSpace(diemGia), e => e.CompanyData.DiemGia.Contains(diemGia))
                    .WhereIf(!string.IsNullOrWhiteSpace(linkThamKhao), e => e.CompanyData.LinkThamKhao.Contains(linkThamKhao))
                    .WhereIf(createdDateMin.HasValue, e => e.CompanyData.CreatedDate >= createdDateMin.Value)
                    .WhereIf(createdDateMax.HasValue, e => e.CompanyData.CreatedDate <= createdDateMax.Value)
                    .WhereIf(companyId != null && companyId != Guid.Empty, e => e.Company != null && e.Company.Id == companyId);
        }

        public async Task<List<CompanyData>> GetListAsync(
            string filterText = null,
            string percent = null,
            string cN = null,
            string tN = null,
            string gia = null,
            string giaTheoPhanTram = null,
            string bienDongGia = null,
            string bienDongCaoThap = null,
            string luuY = null,
            string kL = null,
            string kLPhanTram = null,
            string nN = null,
            string giaTriNN = null,
            string nNMuaCongBan = null,
            string nNMuaTruBan = null,
            string sucManh = null,
            string diemGia = null,
            string linkThamKhao = null,
            DateTime? createdDateMin = null,
            DateTime? createdDateMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, percent, cN, tN, gia, giaTheoPhanTram, bienDongGia, bienDongCaoThap, luuY, kL, kLPhanTram, nN, giaTriNN, nNMuaCongBan, nNMuaTruBan, sucManh, diemGia, linkThamKhao, createdDateMin, createdDateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyDataConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string percent = null,
            string cN = null,
            string tN = null,
            string gia = null,
            string giaTheoPhanTram = null,
            string bienDongGia = null,
            string bienDongCaoThap = null,
            string luuY = null,
            string kL = null,
            string kLPhanTram = null,
            string nN = null,
            string giaTriNN = null,
            string nNMuaCongBan = null,
            string nNMuaTruBan = null,
            string sucManh = null,
            string diemGia = null,
            string linkThamKhao = null,
            DateTime? createdDateMin = null,
            DateTime? createdDateMax = null,
            Guid? companyId = null,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, percent, cN, tN, gia, giaTheoPhanTram, bienDongGia, bienDongCaoThap, luuY, kL, kLPhanTram, nN, giaTriNN, nNMuaCongBan, nNMuaTruBan, sucManh, diemGia, linkThamKhao, createdDateMin, createdDateMax, companyId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyData> ApplyFilter(
            IQueryable<CompanyData> query,
            string filterText,
            string percent = null,
            string cN = null,
            string tN = null,
            string gia = null,
            string giaTheoPhanTram = null,
            string bienDongGia = null,
            string bienDongCaoThap = null,
            string luuY = null,
            string kL = null,
            string kLPhanTram = null,
            string nN = null,
            string giaTriNN = null,
            string nNMuaCongBan = null,
            string nNMuaTruBan = null,
            string sucManh = null,
            string diemGia = null,
            string linkThamKhao = null,
            DateTime? createdDateMin = null,
            DateTime? createdDateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Percent.Contains(filterText) || e.CN.Contains(filterText) || e.TN.Contains(filterText) || e.Gia.Contains(filterText) || e.GiaTheoPhanTram.Contains(filterText) || e.BienDongGia.Contains(filterText) || e.BienDongCaoThap.Contains(filterText) || e.LuuY.Contains(filterText) || e.KL.Contains(filterText) || e.KLPhanTram.Contains(filterText) || e.NN.Contains(filterText) || e.GiaTriNN.Contains(filterText) || e.NNMuaCongBan.Contains(filterText) || e.NNMuaTruBan.Contains(filterText) || e.SucManh.Contains(filterText) || e.DiemGia.Contains(filterText) || e.LinkThamKhao.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(percent), e => e.Percent.Contains(percent))
                    .WhereIf(!string.IsNullOrWhiteSpace(cN), e => e.CN.Contains(cN))
                    .WhereIf(!string.IsNullOrWhiteSpace(tN), e => e.TN.Contains(tN))
                    .WhereIf(!string.IsNullOrWhiteSpace(gia), e => e.Gia.Contains(gia))
                    .WhereIf(!string.IsNullOrWhiteSpace(giaTheoPhanTram), e => e.GiaTheoPhanTram.Contains(giaTheoPhanTram))
                    .WhereIf(!string.IsNullOrWhiteSpace(bienDongGia), e => e.BienDongGia.Contains(bienDongGia))
                    .WhereIf(!string.IsNullOrWhiteSpace(bienDongCaoThap), e => e.BienDongCaoThap.Contains(bienDongCaoThap))
                    .WhereIf(!string.IsNullOrWhiteSpace(luuY), e => e.LuuY.Contains(luuY))
                    .WhereIf(!string.IsNullOrWhiteSpace(kL), e => e.KL.Contains(kL))
                    .WhereIf(!string.IsNullOrWhiteSpace(kLPhanTram), e => e.KLPhanTram.Contains(kLPhanTram))
                    .WhereIf(!string.IsNullOrWhiteSpace(nN), e => e.NN.Contains(nN))
                    .WhereIf(!string.IsNullOrWhiteSpace(giaTriNN), e => e.GiaTriNN.Contains(giaTriNN))
                    .WhereIf(!string.IsNullOrWhiteSpace(nNMuaCongBan), e => e.NNMuaCongBan.Contains(nNMuaCongBan))
                    .WhereIf(!string.IsNullOrWhiteSpace(nNMuaTruBan), e => e.NNMuaTruBan.Contains(nNMuaTruBan))
                    .WhereIf(!string.IsNullOrWhiteSpace(sucManh), e => e.SucManh.Contains(sucManh))
                    .WhereIf(!string.IsNullOrWhiteSpace(diemGia), e => e.DiemGia.Contains(diemGia))
                    .WhereIf(!string.IsNullOrWhiteSpace(linkThamKhao), e => e.LinkThamKhao.Contains(linkThamKhao))
                    .WhereIf(createdDateMin.HasValue, e => e.CreatedDate >= createdDateMin.Value)
                    .WhereIf(createdDateMax.HasValue, e => e.CreatedDate <= createdDateMax.Value);
        }
    }
}