using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using GatewayZ.Models;

namespace GatewayZ.GatewayZDAO
{
    public class UserDAO
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public UserDAO()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(("GatewayZ"));
        }
        public List<string> Users()
        {
            User users = new User();
            var collection = _database.GetCollection<User>("User");
            var filter = Builders<User>.Filter.Eq("displayName", users.displayName);
            var document = collection.Find(filter).ToString();

            var userList = new List<string>();

            foreach (var disName in document)
            {
                userList.Add(document);
            }

            return userList;
        }
    }
}
