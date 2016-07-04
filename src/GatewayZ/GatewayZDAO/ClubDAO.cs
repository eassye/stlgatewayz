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
            _client = new MongoClient();
            _database = _client.GetDatabase(("GatewayZ"));
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
    }
}
