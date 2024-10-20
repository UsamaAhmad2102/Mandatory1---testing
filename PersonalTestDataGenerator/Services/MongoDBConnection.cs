using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using PersonalTestDataGenerator.Models;

namespace PersonalTestDataGenerator.Services
{
    internal class MongoDB_Connection
    { // dette er en test til at forbinde til MongoDB Atlas
        // den burde ikke gøre andet end at forbinde til databasen
        const string connectionUri = "mongodb+srv://younzable:I12YCOUoBUUrb3Ah@mandatory1.czm3p.mongodb.net/?retryWrites=true&w=majority&appName=Mandatory1";
        IMongoClient client;
        IMongoCollection<Person> collection;


        private readonly IMongoCollection<Person> _personsCollection;

        public MongoDB_Connection()
        {
            var client = new MongoClient("mongodb+srv://younzable:I12YCOUoBUUrb3Ah@mandatory1.czm3p.mongodb.net/?retryWrites=true&w=majority&appName=Mandatory1");  // Update the connection string if necessary
            var database = client.GetDatabase("Mandatory1");
            _personsCollection = database.GetCollection<Person>("persons");
        }

        public void SavePersonsToDatabase(List<Person> persons)
        {
            _personsCollection.InsertMany(persons);
        }

    }

  
}
