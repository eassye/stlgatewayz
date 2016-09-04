using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using GatewayZ.Models;
using MongoDB.Bson;

namespace GatewayZ.GatewayZDAO
{
    public class EventDAO
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public EventDAO()
        {
            _client = new MongoClient("mongodb://gatewayz:370zNismo@ds044229.mlab.com:44229/gatewayz");
            _database = _client.GetDatabase(("gatewayz"));
        }

        public void SaveEvent(Event events)
        {
            var collection = _database.GetCollection<Event>("Events");

            var result = collection.InsertOneAsync(events);
        }

        public List<Event> GetEvents()
        {
            var collection = _database.GetCollection<Event>("Events");

            var listEvents = collection.Find(Builders<Event>.Filter.Empty).ToList();

            return listEvents;
        }

        public List<Event> GetTopFiveEvents()
        {
            var collection = _database.GetCollection<Event>("Events");
            var sort = Builders<Event>.Sort.Ascending("StartDate");
            var topFiveEvents = collection.Find(Builders<Event>.Filter.Empty).Sort(sort).Limit(5).ToList();

            return topFiveEvents;
        }
    }
}
