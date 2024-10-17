using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalTestDataGenerator.Models;
using System.Collections.Generic;


namespace PersonDataAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class PersonDataController : ControllerBase
    {
        [HttpGet("cpr")]
        public IActionResult GetPersonData()
        {
            return Ok(new
            {
                cpr = "0101706969"
            });
        }

        [HttpGet("firstname-lastname-gender")]
        public IActionResult GetPersonDataNameGender()
        {
            return Ok(new
            {
                firstname = "John",
                lastname = "Doe",
                gender = "Male"
            });
        }

        [HttpGet("firstname-lastname-gender-date-of-birth")]
        public IActionResult GetPersonDataNameGenderBirthdate()
        {
            return Ok(new
            {
                firstname = "John",
                lastname = "Doe",
                gender = "Male",
                dateOfBirth = "1970"
            });

        }


        [HttpGet("cpr-firstname-lastname-gender")]
        public IActionResult GetPersonDataCprNameGender()
        {
            return Ok(new
            {
                cpr = "John",
                firstname = "Doe",
                lastname = "Male",
                gender = "1970"
            });

        }

        [HttpGet("address")]
        public IActionResult GetAddress()
        {
            return Ok(new
            {
                address = "Randers",

            });

        }

        [HttpGet("mobile-phone-number")]
        public IActionResult GetPhonenumber()
        {
            return Ok(new
            {
                mobilePhoneNumber = "88888888"
            });

        }

        [HttpGet("fake-person")]
        public IActionResult GetPerson()
        {
            return Ok(new
            {
                firstname = "John",
                lastname= "Doe",
                dateOfbirth = "1970",
                gender = "Male",

            });

        }

        [HttpGet("fake-persons/{quantity}")]
        public IActionResult GetPersons(string quantity)
        {
            List<Dictionary<string, Person>> fakePersons = new List<Dictionary<string, Person>>();
            return Ok(new
            {
                fakePerson = fakePersons
            });

        }





    }
}
