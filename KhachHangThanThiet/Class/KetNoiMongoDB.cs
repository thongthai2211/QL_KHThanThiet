using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangThanThiet
{
    public class KetNoiMongoDB
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;

        static KetNoiMongoDB()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("KhachHangThanThiet");
        }

        public static IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
