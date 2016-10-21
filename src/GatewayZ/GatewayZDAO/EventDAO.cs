using GatewayZ.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<string> GetTopFiveEvents()
        {
            var collection = _database.GetCollection<Event>("Events");

            var eventList = new List<string>();

            var query =
                        (from e in collection.AsQueryable<Event>()
                         orderby e.StartDate ascending
                         select new { e.Title, e.StartDate });

            foreach (var title in query)
            {
                var test = DateTime.Parse(title.StartDate);

                if (test >= DateTime.Now)
                {
                    eventList.Add(title.Title);
                    eventList.Add(test.ToString());
                }
            }

            var fiveEvents = eventList.Take(10);

            return fiveEvents.ToList();
        }
    }
}