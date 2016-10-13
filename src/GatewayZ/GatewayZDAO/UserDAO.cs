using System.Collections.Generic;
using System.Linq;
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

        public void Login(User user, string email, string password)
        {
            var collection = _database.GetCollection<User>("User");
            var filter = Builders<User>.Filter.Eq("email", user.email);
            var document = collection.Find(filter).First();
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

        public void EditFirstName(User _user, string email)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.email, email);

            var update = Builders<User>.Update.Set(s => s.firstName, _user.firstName);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void EditLastName(User _user, string email)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.email, email);

            var update = Builders<User>.Update.Set(s => s.lastName, _user.lastName);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void EditEmail(User _user, string email)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.email, email);

            var update = Builders<User>.Update.Set(s => s.email, _user.email);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void EditPhoneNumber(User _user, string email)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.email, email);

            var update = Builders<User>.Update.Set(s => s.phoneNumber, _user.phoneNumber);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void EditPassword(User _user, string email)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.email, email);

            var update = Builders<User>.Update.Set(s => s.password, _user.password);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public void ChangePassword(User _user)
        {
            var collection = _database.GetCollection<User>("User");

            var filter = Builders<User>.Filter.Eq(s => s.email, _user.email) & Builders<User>.Filter.Eq(s => s.answerOne, _user.answerOne) & Builders<User>.Filter.Eq(s => s.answerTwo, _user.answerTwo);

            var update = Builders<User>.Update.Set(s => s.password, _user.password);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }

        public string RetrieveUserDisplay(string userEmail)
        {
            User _user = new User();

            var collection = _database.GetCollection<User>("User");

            var query =
                        from e in collection.AsQueryable<User>()
                        where e.email == userEmail
                        select e.displayName;

            string displayName = query.FirstOrDefault();

            return displayName;
        }

        public bool IsEmailRegistered(string email)
        {
            try
            {
                var collection = _database.GetCollection<User>("User");
                var filter = Builders<User>.Filter.Eq("email", email);
                var document = collection.Find(filter).First();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
