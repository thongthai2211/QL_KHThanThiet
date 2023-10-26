using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangThanThiet
{
    public class NhanVien
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string Manv { get; set; }
        public string Ten { get; set; }
        public string Gioitinh { get; set; }
        
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Ngaysinh { get; set; }

        public string Sdt { get; set; }
        public List<string> Sobanphucvu { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Vitri { get; set; }
        public double Luong { get; set; }
    }
}
