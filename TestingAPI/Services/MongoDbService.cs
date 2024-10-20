using MongoDB.Driver;
using PersonDataAPI.Models;

namespace PersonDataAPI.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Person> _personsCollection;

        public MongoDbService()
        {
            var client = new MongoClient("mongodb+srv://younzable:I12YCOUoBUUrb3Ah@mandatory1.czm3p.mongodb.net/?retryWrites=true&w=majority&appName=Mandatory1");  // Update the connection string if necessary
            var database = client.GetDatabase("Mandatory1");
            _personsCollection = database.GetCollection<Person>("person-names");
        }

        public void SavePersonsToDatabase(List<Person> persons)
        {
            _personsCollection.InsertMany(persons);
        }
    }
}
