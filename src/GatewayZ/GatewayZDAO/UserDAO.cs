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
            _client = new MongoClient("mongodb://gatewayz:370zNismo@ds044229.mlab.com:44229/gatewayz");
            _database = _client.GetDatabase(("gatewayz"));
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

        public List<string> RegisteredUserList()
        {
            var userList = new List<string>();

            User _user = new User();

            var collection = _database.GetCollection<User>("User");

            var query =
                        from e in collection.AsQueryable<User>()
                        select e.displayName;

            foreach (var displayName in query)
            {
                userList.Add(displayName);
            }

            return userList;
        }

        public void SaveUser(User _user)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.displayName, _user.displayName);

            var update = Builders<User>.Update.Set(s => s.isMember, _user.isMember)
                .Set(s => s.club, _user.club)
                .Set(s => s.userType, _user.userType);
                                              
            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void SaveMemberStatus(User _user)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.displayName, _user.displayName);

            var update = Builders<User>.Update.Set(s => s.isMember, _user.isMember);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void SaveMemberClub(User _user)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.displayName, _user.displayName);

            var update = Builders<User>.Update.Set(s => s.club, _user.club);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void SaveUserType(User _user)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.displayName, _user.displayName);

            var update = Builders<User>.Update.Set(s => s.userType, _user.userType);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public string RetrieveUserType(string userEmail)
        {
            User _user = new User();

            var collection = _database.GetCollection<User>("User");

            var query =
                        from e in collection.AsQueryable<User>()
                        where e.email == userEmail
                        select e.userType;

            string userRole = query.FirstOrDefault();

            return userRole;
        }
    }
}
