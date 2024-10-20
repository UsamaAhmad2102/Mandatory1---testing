using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonDataAPI.Models;
using PersonDataAPI.Services;

namespace PersonDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGenerationController : ControllerBase
    {
        [HttpPost("process-and-save-persons")]
        public IActionResult ProcessAndSavePersons()
        {
            // Process persons from the JSON file
            var processedPersons = ProcessPersonsFromJson();

            // Save them to MongoDB
            var mongoService = new MongoDbService();
            mongoService.SavePersonsToDatabase(processedPersons);

            return Ok(new { message = "Persons processed and saved successfully!" });
        }

        private object ProcessPersonsFromJson()
        {
            throw new NotImplementedException();
        }
    }
}
