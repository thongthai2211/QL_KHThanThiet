using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangThanThiet
{
    public class DonGiaBan
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string SoGioThue { get; set; }
        public double TienThueBan { get; set; }
    }
}
