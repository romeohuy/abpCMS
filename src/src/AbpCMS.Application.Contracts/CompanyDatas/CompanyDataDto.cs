using System;
using Volo.Abp.Application.Dtos;

namespace AbpCMS.CompanyDatas
{
    public class CompanyDataDto : FullAuditedEntityDto<Guid>
    {
        public string Percent { get; set; }
        public string CN { get; set; }
        public string TN { get; set; }
        public string Gia { get; set; }
        public string GiaTheoPhanTram { get; set; }
        public string BienDongGia { get; set; }
        public string BienDongCaoThap { get; set; }
        public string LuuY { get; set; }
        public string KL { get; set; }
        public string KLPhanTram { get; set; }
        public string NN { get; set; }
        public string GiaTriNN { get; set; }
        public string NNMuaCongBan { get; set; }
        public string NNMuaTruBan { get; set; }
        public string SucManh { get; set; }
        public string DiemGia { get; set; }
        public string LinkThamKhao { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CompanyId { get; set; }
    }
}