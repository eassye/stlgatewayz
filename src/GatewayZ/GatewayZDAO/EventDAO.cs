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
            _client = new MongoClient();
            _database = _client.GetDatabase(("GatewayZ"));
        }

        public void SaveEvent(Event events)
        {
            var collection = _database.GetCollection<Event>("Events");

            var result = collection.InsertOneAsync(events);
        }

        //public async void GetAllEvents(Event events)
        //{
        //    var collection = _database.GetCollection<Event>("Events");
        //    var filter = new BsonDocument();
        //    var count = 0;
        //    using (var cursor = await collection.FindAsync(filter))
        //    {
        //        while (await cursor.MoveNextAsync())
        //        {
        //            var batch = cursor.Current;
        //            foreach (var document in batch)
        //            {
        //                events.EventID = document.EventID;
        //                events.Title = document.Title;
        //                events.StartDate = document.StartDate;
        //                events.EndDate = document.EndDate;
        //                // process document
        //                count++;
        //            }

        //            batch.AsQueryable();
        //        }
        //    }
        //}

        public async Task<List<Event>> GetEvents()
        {
            var collection = _database.GetCollection<Event>("Events");

            var eventList =  await collection.Find(Builders<Event>.Filter.Empty).ToListAsync();

            return eventList;
        }

        //public List<Event> allDocs()
        //{
        //    var collection = _database.GetCollection<Event>("Events");
        //    var eventList = collection.AsQueryable();

        //    eventList.ToList();

        //    return eventList;
        //}
    }
}
