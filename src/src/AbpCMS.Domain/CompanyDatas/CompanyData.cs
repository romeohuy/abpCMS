using AbpCMS.Companies;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpCMS.CompanyDatas
{
    public class CompanyData : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Percent { get; set; }

        [CanBeNull]
        public virtual string CN { get; set; }

        [CanBeNull]
        public virtual string TN { get; set; }

        [CanBeNull]
        public virtual string Gia { get; set; }

        [CanBeNull]
        public virtual string GiaTheoPhanTram { get; set; }

        [CanBeNull]
        public virtual string BienDongGia { get; set; }

        [CanBeNull]
        public virtual string BienDongCaoThap { get; set; }

        [CanBeNull]
        public virtual string LuuY { get; set; }

        [CanBeNull]
        public virtual string KL { get; set; }

        [CanBeNull]
        public virtual string KLPhanTram { get; set; }

        [CanBeNull]
        public virtual string NN { get; set; }

        [CanBeNull]
        public virtual string GiaTriNN { get; set; }

        [CanBeNull]
        public virtual string NNMuaCongBan { get; set; }

        [CanBeNull]
        public virtual string NNMuaTruBan { get; set; }

        [CanBeNull]
        public virtual string SucManh { get; set; }

        [CanBeNull]
        public virtual string DiemGia { get; set; }

        [CanBeNull]
        public virtual string LinkThamKhao { get; set; }

        public virtual DateTime CreatedDate { get; set; }
        public Guid? CompanyId { get; set; }

        public CompanyData()
        {

        }

        public CompanyData(Guid id, string percent, string cN, string tN, string gia, string giaTheoPhanTram, string bienDongGia, string bienDongCaoThap, string luuY, string kL, string kLPhanTram, string nN, string giaTriNN, string nNMuaCongBan, string nNMuaTruBan, string sucManh, string diemGia, string linkThamKhao, DateTime createdDate)
        {
            Id = id;
            Percent = percent;
            CN = cN;
            TN = tN;
            Gia = gia;
            GiaTheoPhanTram = giaTheoPhanTram;
            BienDongGia = bienDongGia;
            BienDongCaoThap = bienDongCaoThap;
            LuuY = luuY;
            KL = kL;
            KLPhanTram = kLPhanTram;
            NN = nN;
            GiaTriNN = giaTriNN;
            NNMuaCongBan = nNMuaCongBan;
            NNMuaTruBan = nNMuaTruBan;
            SucManh = sucManh;
            DiemGia = diemGia;
            LinkThamKhao = linkThamKhao;
            CreatedDate = createdDate;
        }
    }
}