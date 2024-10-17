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
    {
        const string connectionUri = "mongodb+srv://younzable:I12YCOUoBUUrb3Ah@mandatory1.czm3p.mongodb.net/?retryWrites=true&w=majority&appName=Mandatory1";
        IMongoClient client;
        IMongoCollection<Person> collection;

        public MongoDB_Connection()
        {
            try
            {
                client = new MongoClient(connectionUri);
                var database = client.GetDatabase("Mandatory1");
                collection = database.GetCollection<Person>("Persons");
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                                  "Atlas cluster. Check that the URI includes a valid " +
                                  "username and password, and that your IP address is " +
                                  $"in the Access List. Message: {e.Message}");
                Console.WriteLine(e);
            }
        }
    }
}
