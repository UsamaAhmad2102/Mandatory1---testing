using Microsoft.AspNetCore.Mvc;
using PersonDataAPI.Models;
using PersonDataAPI.Services;
using System.Collections.Generic;

namespace PersonDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGenerationController : ControllerBase
    {
        private readonly MySqlService _sqlServerService;
        private readonly FakeDataGenerator _fakeDataGenerator;

        public DataGenerationController(FakeDataGenerator fakeDataGenerator)
        {
            _sqlServerService = new MySqlService();  // Initialize SqlServerService
            _fakeDataGenerator = fakeDataGenerator;
        }

        [HttpPost("process-and-save-persons")]
        public IActionResult ProcessAndSavePersons()
        {
            FakeDataGenerator fakeData = new FakeDataGenerator();
            // Assuming FakeDataGenerator is implemented and injected
            List<Person> processedPersons = fakeData.ProcessPersonsFromJson();

            // Save to SQL Server
            _sqlServerService.SavePersonsToDatabase(processedPersons);

            return Ok(new { message = "Persons processed and saved successfully!" });
        }

        [HttpGet("get-persons")]
        public IActionResult GetPersons()
        {
            // Retrieve persons from SQL Server
            List<Person> persons = _sqlServerService.GetPersonsFromDatabase();

            return Ok(persons);
        }
    }
}
