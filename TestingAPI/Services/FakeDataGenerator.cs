using Newtonsoft.Json;
using PersonDataAPI.Models;

namespace PersonDataAPI.Services
{
    public class PersonWrapper
    {
        public List<Person> Persons { get; set; }
    }

    public class FakeDataGenerator
    {
        

        public DateTime GenerateRandomBirthdate()
        {
            Random random = new Random();
            int year = random.Next(1940, 2005);  // Generate random year between 1940 and 2005
            int month = random.Next(1, 13);      // Random month (1-12)
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1); // Random valid day in the month

            return new DateTime(year, month, day);
        }

        public string GenerateCPR(DateTime birthdate, string gender)
        {
            Random random = new Random();
            string cprDatePart = birthdate.ToString("ddMMyy"); // Format birthdate as ddMMyy
            int randomDigits = random.Next(1000, 9999);

            // For females, make the last digit even, for males odd
            if (gender.ToLower() == "female" && randomDigits % 2 != 0)
            {
                randomDigits++; // Ensure it's even
            }
            else if (gender.ToLower() == "male" && randomDigits % 2 == 0)
            {
                randomDigits++; // Ensure it's odd
            }

            return cprDatePart + randomDigits.ToString("D4"); // Concatenate date part with random digits
        }

        public string GenerateAddress()
        {
            Random random = new Random();
            string[] streets = { "Main St", "High St", "Maple Ave", "Oak Blvd" };
            string[] towns = { "Copenhagen", "Aarhus", "Odense", "Aalborg" };
            int streetNumber = random.Next(1, 500);
            string floor = random.Next(1, 6) + "th";
            string door = random.Next(1, 50) + "th";
            string postalCode = random.Next(1000, 9999).ToString();

            return $"{streetNumber} {streets[random.Next(streets.Length)]}, {floor}, {door}, {postalCode} {towns[random.Next(towns.Length)]}";
        }

        public string GeneratePhoneNumber()
        {
            Random random = new Random();
            string[] validPrefixes = { "30", "31", "40", "41", "42", "50", "60", "61", "71", "81" };
            string prefix = validPrefixes[random.Next(validPrefixes.Length)];
            string phoneNumber = prefix + random.Next(100000, 999999).ToString();

            return phoneNumber;
        }

        public List<Person> ProcessPersonsFromJson()
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "NameData.json");
            string jsonData = File.ReadAllText(jsonFilePath);
            // Deserialize into the wrapper class that contains the "persons" property
            PersonWrapper wrapper = JsonConvert.DeserializeObject<PersonWrapper>(jsonData);

            // Access the persons list from the wrapper
            List<Person> persons = wrapper.Persons;

            List<Person> processedPersons = new List<Person>();

            for (int i = 0; i < Math.Min(100, persons.Count); i++)
            {
                var person = persons[i];

                // Generate additional data
                DateTime birthdate = GenerateRandomBirthdate();
                string cpr = GenerateCPR(birthdate, person.Gender);
                string address = GenerateAddress();
                string phoneNumber = GeneratePhoneNumber();

                // Create a new person object with the additional fields
                processedPersons.Add(new Person
                {
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Gender = person.Gender,
                    CPR = cpr,
                    Birthdate = birthdate,
                    Address = address,
                    MobilePhoneNumber = phoneNumber
                });
            }

            return processedPersons;
        }




    }
}
