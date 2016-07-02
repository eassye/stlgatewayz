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
        public List<string> UsersList(string club)
        {
            var userList = new List<string>();

            User _user = new User();

            var collection = _database.GetCollection<User>("User");

            var query =
                        from e in collection.AsQueryable<User>()
                        where e.club == club
                        select e.displayName;

            foreach (var displayName in query)
            {
                userList.Add(displayName);
            }

            return userList;
        }
    }
}
