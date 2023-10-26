using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangThanThiet
{
    public class KHTT
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public int SoLanThue { get; set; }
        public string LoaiKH
        {
            get
            {
                return SoLanThue >= 3 ? "Khách Hàng Thân Thiết" : "Khách Hàng Bình Thường";
            }
        }
    }

}
