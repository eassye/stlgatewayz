using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using GatewayZ.Models;

namespace GatewayZ.GatewayZDAO
{
    public class EventDAO
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public EventDAO()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(("GatewayZ"));
        }

        public void SaveEvent(Event events)
        {
            var collection = _database.GetCollection<Event>("Events");

            var result = collection.InsertOneAsync(events);
        }

        public async void GetAllEvents()
        {
            var collection = _database.GetCollection<Event>("Events");

            var documents = await collection.Find(Builders<Event>.Filter.Empty).ToListAsync();
        }
    }
}
