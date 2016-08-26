using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using GatewayZ.Models;

namespace GatewayZ.GatewayZDAO
{
    public class ClubDAO
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static Club _Club;

        public ClubDAO()
        {
            _client = new MongoClient("mongodb://gatewayz:370zNismo@ds044229.mlab.com:44229/gatewayz");
            _database = _client.GetDatabase(("gatewayz"));
            _Club = new Club();
        }

        public List<string> ListOfClubs()
        {
            var clubList = new List<string>();

            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        select e.clubName;

            foreach (var clubName in query)
            {
                clubList.Add(clubName);
            }

            return clubList;
        }

        public string GetClubCode(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.clubCode;

            
            return query.ToString();
        }

        public string GetClubHistory(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.clubHistory;

            return query.ToString();
        }

        public string GetPresident(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.president;

            return query.ToString(); 
        }

        public string GetVicePresident(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.vicePresident;

            return query.ToString(); 
        }

        public string GetTreasurer(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.treasurer;

            return query.ToString();
        }

        public string GetSecretary(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.secretary;

            return query.ToString();
        }

        public string GetWebMaster(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.webMaster;

            return query.ToString();
        }

        public string GetSocialMediaDirector(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.socialMediaDirector;

            return query.ToString();
        }

        public string GetMembershipDirector(string clubName)
        {
            var collection = _database.GetCollection<Club>("Club");

            var query =
                        from e in collection.AsQueryable<Club>()
                        where e.clubName == clubName
                        select e.membershipDirector;

            return query.ToString();
        }

        public void SaveClub(Club _club)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(("GatewayZ"));

            var collection = _database.GetCollection<Club>("Club");

            var filter = Builders<Club>.Filter.Eq(s => s.clubName, _club.clubName);

            var update = Builders<Club>.Update.Set(s => s.clubCode, _club.clubCode)
                .Set(s => s.clubHistory, _club.clubHistory)
                .Set(s => s.president, _club.president)
                .Set(s => s.vicePresident, _club.vicePresident)
                .Set(s => s.treasurer, _club.treasurer)
                .Set(s => s.secretary, _club.secretary)
                .Set(s => s.membershipDirector, _club.membershipDirector)
                .Set(s => s.socialMediaDirector, _club.socialMediaDirector)
                .Set(s => s.webMaster, _club.webMaster);

            var result = collection.UpdateOneAsync(filter, update);

            result.Wait();
        }
    }
}
