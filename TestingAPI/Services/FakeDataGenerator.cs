using Newtonsoft.Json;
using PersonDataAPI.Models;
using PersonalTestDataGenerator.Validation;

namespace PersonDataAPI.Services
{
    public class PersonWrapper
    {
        public List<Person> Persons { get; set; }
    }

    public class FakeDataGenerator
    {
        private CprValidator cprValidator = new();
        private AddressValidator addressValidator = new();
        private PhoneValidator phoneValidator = new();
        

        public string GenerateRandomBirthdate()
        {
            Random random = new Random();
            int monthAsInt = 0;

            DateTime startDate = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - startDate).Days;
            int randomDay = random.Next(range);
            DateTime birthDate = startDate.AddDays(randomDay);
            string day = birthDate.Day.ToString("00");
            string month = birthDate.Month.ToString("00");
            string year = (birthDate.Year % 100).ToString("00");

            bool yearIsValid = cprValidator.CheckDateOfBirthYear(year);
            if (!yearIsValid) throw new Exception($"Invalid year format: {year}");


            bool monthIsValid = cprValidator.CheckDateOfBirthMonth(month);
            if (!monthIsValid) throw new Exception($"Invalid month format: {month}");
            

            if (month.StartsWith("0"))
            {
                month = month.Replace("0", "");
                monthAsInt = int.Parse(month);
            } else
            {
                monthAsInt = int.Parse(month);
            }

            bool dayIsValid = cprValidator.CheckDateOfBirthDay(day, monthAsInt);
            if (!dayIsValid) throw new Exception($"Invalid day format: {day}");


            return birthDate.Day.ToString("00") + birthDate.Month.ToString("00") + (birthDate.Year % 100).ToString("00");
        }
    

        public string GenerateCPR(string birthdate, string gender)
        {
            Random random = new Random();
            int randomDigits = random.Next(1000, 9999);

    
            if (gender.ToLower() == "female" && randomDigits % 2 != 0)
            {
                randomDigits++;
            }
            else if (gender.ToLower() == "male" && randomDigits % 2 == 0)
            {
                randomDigits++;
            }

            string lastFourDigits = randomDigits.ToString("D4");

            bool cprIsValid = cprValidator.CheckLastFourDigits(lastFourDigits, gender);

            if (!cprIsValid) throw new Exception($"Invalid cpr in last four digits format: {birthdate}");


            return  birthdate + lastFourDigits;
        }

        public string GenerateFakeAddress()
        {
            Random random = new Random();

            string[] streets = { "Main St", "High St", "Maple Ave", "Oak Blvd" };
            string[] towns = { "Copenhagen", "Aarhus", "Odense", "Aalborg" };
            string street = GenerateRandomStreet();
            string number = GenerateRandomNumber();
            string floor = GenerateRandomFloor();
            string door = GenerateRandomDoor();

            return $"{towns[random.Next(towns.Length)]}, {streets[random.Next(streets.Length)]}, {number}, {floor}, {door}";
        }


        public string GenerateRandomStreet()
        {
            Random random = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int length = random.Next(5, 15); // Random street length between 5 and 15 characters
            char[] streetChars = new char[length];



            for (int i = 0; i < length; i++)
            {
                streetChars[i] = characters[random.Next(characters.Length)];
            }

            return new string(streetChars);
        }

        public string GenerateRandomNumber()
        {
            Random random = new Random();
            int number = random.Next(1, 999);
            string numberAsString = number.ToString();

            if (random.Next(0, 2) == 1)
            {
                char letter = (char)random.Next('A', 'Z' + 1);
                numberAsString = $"{number}{letter}";
            }
            number.ToString();
            bool numberIsValid = addressValidator.ValidateStreetNumber(numberAsString);
            if (!numberIsValid) throw new Exception($"Invalid streetnumber: {numberAsString}");

            return numberAsString;
        }


        public string GenerateRandomFloor()
        {
            string floor = "";
            Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
                floor = "st";
            }
            else 
            {
                floor = random.Next(1, 99).ToString();
            }

            bool floorIsValid = addressValidator.ValidateFloor(floor);
            if (!floorIsValid) throw new Exception($"Invalid floor format: {floor}");


            return floor;
        }


        public string GenerateRandomDoor()
        {
            string door = "";
            Random random = new Random();
            int choice = random.Next(0, 5);

            if (choice == 0) door = "th";
            if (choice == 1) door = "mf";
            if (choice == 2) door = "tv";
            if (choice == 3)
            {
                int number = random.Next(1, 50);
                door = number.ToString();
            }
            if (choice == 4)
            {
                char letter = (char)random.Next('a', 'z' + 1);
                int digits = random.Next(1, 4);
                string numberPart = "-" + random.Next(0, (int)Math.Pow(10, digits)).ToString("D" + digits);

                door = $"{letter}{numberPart}";
            }


            bool doorIsValid = addressValidator.ValidateDoor(door);
            if (!doorIsValid) throw new Exception($"Invalid door format: {door}");

            return door;
        }

        public string GeneratePhoneNumber()
        {
            string[] PhonePrefixes = new String[]
            {
                "2", "30", "31", "40", "41", "42", "50", "51", "52", "53", "60", "61", "71", "81", "91", "92", "93",
                "342", "344", "345", "346", "347", "348", "349", "356", "357", "359", "362", "365", "366", "389",
                "398", "431", "441", "462", "466", "468", "472", "474", "476", "478", "485", "486", "488", "489",
                "493", "494", "495", "496", "498", "499", "542", "543", "545", "551", "552", "556", "571", "572",
                "573", "574", "577", "579", "584", "586", "587", "589", "597", "598", "627", "629", "641", "649",
                "658", "662", "663", "664", "665", "667", "692", "693", "694", "697", "771", "772", "782", "783",
                "785", "786", "788", "789", "826", "827", "829"
            };

            Random random = new Random();
            string prefix = PhonePrefixes[random.Next(PhonePrefixes.Length)];
            string phoneNumber = prefix;

            for (int i = 0; i < 8 - prefix.Length; i++)
            {
                phoneNumber += random.Next(10).ToString();
            }

            bool phonenumberIsValid = phoneValidator.ValidatePhoneNumberPrefix(phoneNumber, PhonePrefixes);
            if (!phonenumberIsValid) throw new Exception($"Invalid phonenumber format: {phoneNumber}"); 


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
                string birthdate = GenerateRandomBirthdate();
                string cpr = GenerateCPR(birthdate, person.Gender);
                string address = GenerateFakeAddress();
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
