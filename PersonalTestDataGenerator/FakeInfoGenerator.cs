using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using PersonalTestDataGenerator.Models;





namespace PersonalTestDataGenerator
{
    public class FakeInfoGenerator
    {
        public string firstName;
        public string lastName;
        public string gender;
        public DateTime birthDate;
        public string cpr;
        public string postalcode;
        public string street;
        public string number;
        public string floor;
        public string door;
        public string town;
        public string phone;
        public string jsonFilePath = "NameData.json";
        public string connectionString = "Server=mandatorytestserver.mysql.database.azure.com;Port=3306;Database=addresses;User ID=admin123;Password=Password123;Charset=utf8;";
        private MySqlConnection connection;


        public FakeInfoGenerator(string connectionString = null)
        {
            random = new Random();
            if (!string.IsNullOrEmpty(connectionString))
            {
                this.connection = new MySqlConnection(connectionString);
                this.connection.Open();
            }
        }

        public void SetGender(string gender)
        {
            this.gender = gender;
        }


        public FakeInfoGenerator()
        {
            Random random = new Random();
            SetFullNameAndGender();
            setBirthDate();
            setCpr();
            GenerateFakeAddress();
            GeneratePostalandtown();
            PhoneGenerator phoneGenerator = new PhoneGenerator();
            this.phone = PhoneGenerator.GeneratePhoneNumber();
        }

        public Random random = new Random();





        public void GeneratePostalandtown()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();



            MySqlCommand cmd = new MySqlCommand("SELECT cPostalCode, cTownName FROM postal_code", connection);
            var postalAndTownData = new postalsAndTownsData();



            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    PostalAndTown postalAndTown = new PostalAndTown
                    {
                        PostalCode = reader["cPostalCode"].ToString(),
                        Town = reader["cTownName"].ToString()
                    };



                    postalAndTownData.postalsAndTowns.Add(postalAndTown);


                }
            }
            int randomNumber = random.Next(postalAndTownData.postalsAndTowns.Count);

            this.postalcode = postalAndTownData.postalsAndTowns[randomNumber].PostalCode;
            this.town = postalAndTownData.postalsAndTowns[randomNumber].Town;

        }


        public void SetFullNameAndGender()
        {
            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException($"The file '{jsonFilePath}' was not found.");
            }
            string jsonContent = File.ReadAllText(jsonFilePath);
            var personsData = JsonConvert.DeserializeObject<personsData>(jsonContent);
            if (personsData == null)
            {
                throw new InvalidDataException("The JSON content could not be deserialized.");
            }
            var persons = personsData.Persons;
            Random random = new Random();
            int randomNummber = random.Next(persons.Count);
            if (persons == null || persons.Count == 0)
            {
                throw new InvalidOperationException("The JSON file does not contain any person.");
            }
            this.firstName = persons[randomNummber].FirstName;
            this.lastName = persons[randomNummber].LastName;
            this.gender = persons[randomNummber].Gender;
        }



        //Brug denne funktion til at sætte random address
        //Du kan bruge private Address address; til at sætte data
        //eksempler this.address.Street = street;
        //this.address.Street = street;
        //this.address.Number = number;
        public void GenerateFakeAddress()
        {
            Random random = new Random();


            this.street = GenerateRandomStreet();
            this.number = GenerateRandomNumber();
            this.floor = GenerateRandomFloor();
            this.door = GenerateRandomDoor();
        }


        private static string GenerateRandomStreet()
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

        private static string GenerateRandomNumber()
        {
            Random random = new Random();
            int number = random.Next(1, 999);
            if (random.Next(0, 2) == 1)
            {
                char letter = (char)random.Next('A', 'Z' + 1);
                return $"{number}{letter}";
            }



            return number.ToString();
        }


        private static string GenerateRandomFloor()
        {
            Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
                return "st";
            }
            return random.Next(1, 99).ToString();
        }


        private static string GenerateRandomDoor()
        {
            Random random = new Random();
            int choice = random.Next(0, 5);

            if (choice == 0) return "th";
            if (choice == 1) return "mf";
            if (choice == 2) return "tv";
            if (choice == 3)
            {
                int number = random.Next(1, 50);
                return number.ToString();
            }
            if (choice == 4)
            {
                char letter = (char)random.Next('a', 'z' + 1);
                string numberPart = "";
                if (random.Next(0, 2) == 1)
                {
                    int digits = random.Next(1, 4);
                    numberPart = "-" + random.Next(0, (int)Math.Pow(10, digits)).ToString("D" + digits);
                }
                return $"{letter}{numberPart}";
            }

            return "";
        }

        public void setBirthDate()
        {
            DateTime startDate = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - startDate).Days;
            int randomDay = random.Next(range);
            this.birthDate = startDate.AddDays(randomDay);
        }

        public void setCpr() {
            string birthdatePart = birthDate.ToString("ddMMyy");
            int fourDigits = random.Next(0, 10000);
            if (gender == "female")
            {
                if (fourDigits % 2 != 0) fourDigits--;
            }
            else
            {
                if (fourDigits % 2 == 0) fourDigits++;
            }
            string fourDigitsString = fourDigits.ToString("D4");
            this.cpr = birthdatePart + fourDigitsString;
        }

        public Person GetFullNameAndGender()
        {
            return new Person { FirstName = this.firstName, LastName = this.lastName, Gender = this.gender };
        }

        public Person GetCpr()
        {
            return new Person { cpr = this.cpr };
        }

        public Person GetFullNameGenderDateOfBirth()
        {
            return new Person { FirstName = this.firstName, LastName = this.lastName, Gender = this.gender, birthDate = this.birthDate };
        }

        public Person GetCprFullNameGender()
        {
            return new Person { cpr = this.cpr, FirstName = this.firstName, LastName = this.lastName, Gender = this.gender };
        }

        public Person GetCprFullNameGenderDateOfBirth()
        {
            return new Person { cpr = this.cpr, FirstName = this.firstName, LastName = this.lastName, Gender = this.gender, birthDate = this.birthDate };
        }

        public Person GetPhone()
        {
            return new Person { phone = this.phone };
        }

        public Address GetAddress()
        {
            return new Address { Street = this.street, Number = this.number, Floor = this.floor, Door = this.door, PostalCode = this.postalcode, Town = this.town };
        }

        public Person GetAllInformation()
        {
            Address address = new Address();
            address = GetAddress();
            return new Person { FirstName = this.firstName, LastName = this.lastName, Gender = this.gender, birthDate = this.birthDate, cpr = this.cpr, phone = this.phone,
                Address = new Address
                {
                    Street = this.street,
                    Number = this.number,
                    Floor = this.floor,
                    Door = this.door,
                    PostalCode = this.postalcode,
                    Town = this.town
                }
            };
        }

        public personsData GetpersonsInformation(int amount)
        {
            if (amount < 2) { amount = 2; }
            if (amount > 100) { amount = 100; }

            var fakePersons = new personsData { Persons = new List<Person>() };

            for (int i = 0; i < amount; i++)
            {
                SetFullNameAndGender();
                setBirthDate();
                setCpr();
                GenerateFakeAddress();
                GeneratePostalandtown();
                this.phone = PhoneGenerator.GeneratePhoneNumber();

                var person = GetAllInformation();

                fakePersons.Persons.Add(person);
            }

            return fakePersons;
        }
    }
}