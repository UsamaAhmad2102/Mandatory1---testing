using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PersonDataAPI.Services;
using System.Collections.Generic;
using System.Configuration;
using PersonDataAPI.Models;


namespace PersonDataAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class PersonDataController : ControllerBase
    {

        private readonly string _connectionString;
        public PersonDataController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

       
        [HttpGet("cpr")]
        public IActionResult GetPersonDataCpr()
        {
            string cpr = GetRandomPersonData("CPR");
            return Ok(new { cpr });
        }

       
        [HttpGet("firstname-lastname-gender")]
        public IActionResult GetPersonDataNameGender()
        {
            var person = GetRandomPerson("firstname, lastname, gender");
            return Ok(new
            {
                firstname = person.Firstname,
                lastname = person.Lastname,
                gender = person.Gender
            });
        }

        
        [HttpGet("firstname-lastname-gender-date-of-birth")]
        public IActionResult GetPersonDataNameGenderBirthdate()
        {
            var person = GetRandomPerson("firstname, lastname, gender, dateOfBirth");
            return Ok(new
            {
                firstname = person.Firstname,
                lastname = person.Lastname,
                gender = person.Gender,
                dateOfBirth = person.Birthdate.ToString("yyyy-MM-dd")  
            });
        }

        [HttpGet("cpr-firstname-lastname-gender")]
        public IActionResult GetPersonDataCprNameGender()
        {
            var person = GetRandomPerson("CPR, firstname, lastname, gender");
            return Ok(new
            {
                cpr = person.CPR,
                firstname = person.Firstname,
                lastname = person.Lastname,
                gender = person.Gender
            });
        }

        [HttpGet("address")]
        public IActionResult GetAddress()
        {
            string address = GetRandomPersonData("address");
            return Ok(new { address });
        }

        [HttpGet("mobile-phone-number")]
        public IActionResult GetPhonenumber()
        {
            string phoneNumber = GetRandomPersonData("PhoneNumber");
            return Ok(new { mobilePhoneNumber = phoneNumber });
        }

        [HttpGet("fake-person")]
        public IActionResult GetPerson()
        {
            var person = GetRandomPerson("firstname, lastname, gender, dateOfBirth");
            return Ok(new
            {
                firstname = person.Firstname,
                lastname = person.Lastname,
                gender = person.Gender,
                dateOfbirth = person.Birthdate
            });
        }

        // Helper method to retrieve random data from the database one field
        private string GetRandomPersonData(string column)
        {
            string data = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT TOP 1 {column} FROM Person ORDER BY NEWID()";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        data = command.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error: {ex.Message}");
            }
            return data;
        }

        // Helper method to retrieve random person details from the database
        private Person GetRandomPerson(string columns)
        {
            Person person = new Person();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT TOP 1 {columns} FROM Person ORDER BY NEWID()";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                person.Firstname = reader.GetString(reader.GetOrdinal("firstname"));
                                person.Lastname = reader.GetString(reader.GetOrdinal("lastname"));
                                person.Gender = reader.GetString(reader.GetOrdinal("gender"));
                                person.CPR = reader.GetString(reader.GetOrdinal("CPR"));


                                if (reader["dateOfBirth"] != DBNull.Value)
                                {
                                    DateTime dateOfBirth = (DateTime)reader["dateOfBirth"];
                                    Console.WriteLine($"Retrieved DateOfBirth: {dateOfBirth}");
                                    person.Birthdate = dateOfBirth;
                                }
                                else
                                {
                                    person.Birthdate = DateTime.MinValue;  // Handle null values
                                }

                                person.Address = reader.GetString(reader.GetOrdinal("address"));
                                person.MobilePhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return person;
        }

        [HttpGet("fake-persons/{quantity}")]
        public IActionResult GetPersons(int quantity)
        {
            if (quantity < 1 || quantity > 100)
            {
                return BadRequest(new { message = "Quantity must be between 1 and 100" });
            }

            List<Person> fakePersons = new List<Person>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT TOP (@Quantity) firstname, lastname, gender FROM Person";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity", quantity);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Person person = new Person
                                {
                                    Firstname = reader["Firstname"].ToString(),
                                    Lastname = reader["Lastname"].ToString(),
                                    Gender = reader["Gender"].ToString()
                                };

                                fakePersons.Add(person);
                            }
                        }
                    }
                }

                return Ok(fakePersons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching data", error = ex.Message });
            }
           
        }






    }
}
