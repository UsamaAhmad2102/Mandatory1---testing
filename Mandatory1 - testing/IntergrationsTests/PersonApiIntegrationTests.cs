using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mandatory1___testing.IntergrationsTests
{
    [TestClass]
    public class PersonApiIntegrationTests
    {
        private readonly HttpClient _client;

        public PersonApiIntegrationTests()
        {
            
            var application = new WebApplicationFactory<PersonDataAPI.Program>();
            _client = application.CreateClient();
        }

        [TestMethod]
        public async Task GetPersons_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/DataGeneration/get-persons");
            response.EnsureSuccessStatusCode();
        }
    }
}
