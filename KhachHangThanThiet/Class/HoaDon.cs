using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KhachHangThanThiet
{
    public class HoaDon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("MaHoaDon")]
        public string MaHoaDon { get; set; }

        [BsonElement("MaKH")]
        public string MaKH { get; set; }

        [BsonElement("SoBan")]
        public string SoBan { get; set; }

        [BsonElement("TenKH")]
        public string TenKH { get; set; }

        [BsonElement("Ngaysinh")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Ngaysinh { get; set; }

        [BsonIgnore]
        public string NgaySinhString
        {
            get { return Ngaysinh.ToString("dd/MM/yyyy"); }
        }

        [BsonElement("GioiTinh")]
        public string GioiTinh { get; set; }

        [BsonElement("DiaChi")]
        public string DiaChi { get; set; }

        [BsonElement("Sdt")]
        public string Sdt { get; set; }

        [BsonElement("NgheNghiep")]
        public string NgheNghiep { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("NhanVienPhucVu")]
        public string NhanVienPhucVu { get; set; }

        [BsonElement("SoGioThue")]
        public string SoGioThue { get; set; }

        [BsonElement("TienThueBan")]
        public double TienThueBan { get; set; }

        [BsonElement("ThoiGianBatDau")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ThoiGianBatDau { get; set; }

        [BsonElement("ThoiGianKetThuc")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ThoiGianKetThuc { get; set; }

        [BsonElement("ThanhTien")]
        public string ThanhTien { get; set; }
    }
}
