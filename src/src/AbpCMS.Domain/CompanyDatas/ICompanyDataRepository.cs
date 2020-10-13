using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpCMS.CompanyDatas
{
    public interface ICompanyDataRepository : IRepository<CompanyData, Guid>
    {
        Task<CompanyDataWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<CompanyDataWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<List<CompanyData>> GetListAsync(
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
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}