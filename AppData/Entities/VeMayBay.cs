using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Entities
{
    public class VeMayBay
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TenKhachHang { get; set; }
        public string SoHieuChuyenBay { get; set; }
        public DateTime NgayBay {  get; set; }
        public string DiemKhoiHanh { get; set; }    
        public string DiemDen { get; set; }
        public decimal GiaVe {  get; set; }
    }
}
