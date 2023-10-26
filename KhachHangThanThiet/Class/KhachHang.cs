using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KhachHangThanThiet
{
    public class KhachHang
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("MaKH")]
        public string Makh { get; set; }

        [BsonElement("Ten")]
        public string Ten { get; set; }

        [BsonElement("Ngaysinh")]
        public DateTime Ngaysinh { get; set; }

        [BsonElement("Sdt")]
        public string Sdt { get; set; }

        [BsonElement("Soban")]
        public string Soban { get; set; }

        [BsonElement("Diachi")]
        public string Diachi { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Nghenghiep")]
        public string Nghenghiep { get; set; }
    }
}
