using PersonalTestDataGenerator.Models;
using PersonalTestDataGenerator;



namespace Mandatory1___testing.UnitTests
{
    [TestClass]
    public class FakeInfoGeneratorTests
    {

  



        //Test for the GetFullNameAndGender() function
        [TestMethod]
        public void TestGetFullNameAndGender()
        {
            var generator = new FakeInfoGenerator();



            var result = generator.GetFullNameAndGender();



            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.LastName));
            Assert.IsTrue(result.Gender == "male" || result.Gender == "female");
        }



        //Test for the GetpersonsInformation() function
        [TestMethod]
        public void TestGetPersonsInformationCheckingForValuesThatMustNotBeNull()
        {
            var generator = new FakeInfoGenerator();
            int numberOfPersons = 100;



            var personsData = generator.GetpersonsInformation(numberOfPersons);



            Assert.IsTrue(personsData.Persons.All(p =>
                !string.IsNullOrEmpty(p.FirstName) &&
                !string.IsNullOrEmpty(p.LastName) &&
                !string.IsNullOrEmpty(p.Gender) &&
                p.birthDate.HasValue &&
                !string.IsNullOrEmpty(p.cpr) &&
                !string.IsNullOrEmpty(p.phone) &&
                p.Address != null &&
                !string.IsNullOrEmpty(p.Address.Street) &&
                !string.IsNullOrEmpty(p.Address.Floor) &&
                !string.IsNullOrEmpty(p.Address.Door) &&
                !string.IsNullOrEmpty(p.Address.PostalCode) &&
                !string.IsNullOrEmpty(p.Address.Town)));
        }



    }
    [TestClass]

    public class GetDataTests
    {

        [TestMethod]
        public void TestGetFullNameAndGender()
        {
            var generator = new FakeInfoGenerator();

            var result = generator.GetFullNameAndGender();

            Assert.IsFalse(string.IsNullOrEmpty(result.FirstName));
            Assert.IsFalse(string.IsNullOrEmpty(result.LastName));
            Assert.IsFalse(string.IsNullOrEmpty(result.Gender));
        }

        [TestMethod]
        public void TestGetCpr()
        {
            var generator = new FakeInfoGenerator();

            var result = generator.GetCpr();


            Assert.IsFalse(string.IsNullOrEmpty(result.cpr));
        }

        [TestMethod]
        public void TestGetFullNameGenderDateOfBirth()
        {
            var generator = new FakeInfoGenerator();
            var result = generator.GetFullNameGenderDateOfBirth();

            Assert.IsFalse(string.IsNullOrEmpty(result.FirstName));
            Assert.IsFalse(string.IsNullOrEmpty(result.LastName));
            Assert.IsFalse(string.IsNullOrEmpty(result.Gender));
            Assert.IsNotNull(result.birthDate);
        }

        [TestMethod]
        public void TestGetCprFullNameGender()
        {
            var generator = new FakeInfoGenerator();
            var result = generator.GetCprFullNameGender();

            Assert.IsFalse(string.IsNullOrEmpty(result.cpr));
            Assert.IsFalse(string.IsNullOrEmpty(result.FirstName));
            Assert.IsFalse(string.IsNullOrEmpty(result.LastName));
            Assert.IsFalse(string.IsNullOrEmpty(result.Gender));
        }

        [TestMethod]
        public void TestGetCprFullNameGenderDateOfBirth()
        {
            var generator = new FakeInfoGenerator();
            var result = generator.GetCprFullNameGenderDateOfBirth();

            Assert.IsFalse(string.IsNullOrEmpty(result.cpr));
            Assert.IsFalse(string.IsNullOrEmpty(result.FirstName));
            Assert.IsFalse(string.IsNullOrEmpty(result.LastName));
            Assert.IsFalse(string.IsNullOrEmpty(result.Gender));
            Assert.IsNotNull(result.birthDate);
        }

        [TestMethod]
        public void TestGetAddress()
        {
            var generator = new FakeInfoGenerator();
            var result = generator.GetAddress();

     
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.Street));
            Assert.IsFalse(string.IsNullOrEmpty(result.Number));
            Assert.IsFalse(string.IsNullOrEmpty(result.Floor));
            Assert.IsFalse(string.IsNullOrEmpty(result.Door));
            Assert.IsFalse(string.IsNullOrEmpty(result.PostalCode));
            Assert.IsFalse(string.IsNullOrEmpty(result.Town));

        }

        [TestMethod]
        public void TestGetPhone()
        {
            var generator = new FakeInfoGenerator();
            var result = generator.GetPhone();

            Assert.IsFalse(string.IsNullOrEmpty(result.phone));
        }

        [TestMethod]
        public void TestGetAllInformation()
        {
            var generator = new FakeInfoGenerator();
            var result = generator.GetAllInformation();

            Assert.IsFalse(string.IsNullOrEmpty(result.FirstName));
            Assert.IsFalse(string.IsNullOrEmpty(result.LastName));
            Assert.IsFalse(string.IsNullOrEmpty(result.Gender));
            Assert.IsNotNull(result.birthDate);
            Assert.IsFalse(string.IsNullOrEmpty(result.cpr));

            Assert.IsNotNull(result.Address);
            Assert.IsFalse(string.IsNullOrEmpty(result.Address.Street));
            Assert.IsFalse(string.IsNullOrEmpty(result.Address.Number));
            Assert.IsFalse(string.IsNullOrEmpty(result.Address.Floor));
            Assert.IsFalse(string.IsNullOrEmpty(result.Address.Door));
            Assert.IsFalse(string.IsNullOrEmpty(result.Address.PostalCode));
            Assert.IsFalse(string.IsNullOrEmpty(result.Address.Town));


            Assert.IsFalse(string.IsNullOrEmpty(result.phone));
        }
    }




    [TestClass]
    public class BlackBoxTestGetpersonsInformation
    {
        [TestMethod]
        public void TestGetpersonsInformationLowerBoundary()
        {
            var generator = new FakeInfoGenerator();
            int numberOfPersons = 1;



            var result = generator.GetpersonsInformation(numberOfPersons);





            Assert.AreEqual(2, result.Persons.Count);
        }



        [TestMethod]
        public void TestGetpersonsInformationUpperBoundary()
        {
            var generator = new FakeInfoGenerator();
            int numberOfPersons = 101;



            var result = generator.GetpersonsInformation(numberOfPersons);





            Assert.AreEqual(100, result.Persons.Count);
        }



        [TestMethod]
        public void TestGetpersonsInformationMiddleValue()
        {
            var generator = new FakeInfoGenerator();
            int numberOfPersons = 50;



            var result = generator.GetpersonsInformation(numberOfPersons);





            Assert.AreEqual(50, result.Persons.Count);
        }
        [TestMethod]
        public void TestGetpersonsExactLowerBoundary()
        {
            var generator = new FakeInfoGenerator();
            int numberOfPersons = 2;



            var result = generator.GetpersonsInformation(numberOfPersons);





            Assert.AreEqual(2, result.Persons.Count);
        }



        [TestMethod]
        public void TestGetpersonsExactUpperBoundary()
        {
            var generator = new FakeInfoGenerator();
            int numberOfPersons = 100;



            var result = generator.GetpersonsInformation(numberOfPersons);





            Assert.AreEqual(100, result.Persons.Count);
        }



        //tests for fake addresses



        [TestMethod]
        public void GenerateFakeAddress_ValidatesComponents()
        {
            // Arrange
            for (int i = 0; i < 100; i++) // Generate 100 fake addresses
            {



                FakeInfoGenerator generator = new FakeInfoGenerator();



                // Split the fake address into components



                // Act
                // Validate each component
                string number = generator.number;
                string street = generator.street;
                string floor = generator.floor;
                string door = generator.door;
                string postalCode = generator.postalcode;
                string town = generator.town;



                // Assert
                // Validate Number
                Assert.IsFalse(string.IsNullOrWhiteSpace(number), "Number should not be empty");
                if (number.Length > 1)
                {
                    Assert.IsTrue(char.IsDigit(number[0]), "First character of number should be a digit");

                }
                else
                {
                    Assert.IsTrue(char.IsDigit(number[0]), "Number should be a digit");
                }



                // Validate Street
                Assert.IsFalse(string.IsNullOrWhiteSpace(street), "Street should not be empty");
                Assert.IsTrue(street.Length >= 5 && street.Length <= 15, "Street length should be between 5 and 15 characters");



                // Validate Floor
                Assert.IsFalse(string.IsNullOrWhiteSpace(floor), "Floor should not be empty");
                if (floor != "st")
                {
                    int floorNumber;
                    Assert.IsTrue(int.TryParse(floor, out floorNumber), "Floor should be a number if not 'st'");
                    Assert.IsTrue(floorNumber >= 1 && floorNumber <= 99, "Floor number should be between 1 and 99");
                }



                // Validate Door
                Assert.IsFalse(string.IsNullOrWhiteSpace(door), "Door should not be empty");
                if (door != "th" && door != "mf" && door != "tv")
                {
                    if (char.IsLetter(door[0]))
                    {
                        string[] parts = door.Split('-');
                        Assert.IsTrue(parts.Length <= 2, "Door format should be 'letter' or 'letter-number' or 'letter-number-number'");
                        Assert.IsTrue(parts.Length == 1 || (parts.Length == 2 && int.TryParse(parts[1], out int _)), "Invalid door format");
                    }
                    else
                    {
                        int doorNumber;
                        Assert.IsTrue(int.TryParse(door, out doorNumber), "Door should be a number or start with a letter");
                        Assert.IsTrue(doorNumber >= 1 && doorNumber <= 50, "Door number should be between 1 and 50");
                    }
                }



                // Validate Postal Code and Town
                Assert.IsFalse(string.IsNullOrWhiteSpace(postalCode), "Postal code and town should not be empty");
            }
        }

        [TestMethod]
        public void GenerateFakeAddress_Repeatability()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();



            // Generate multiple addresses and ensure they are not equal.
            Address address1 = generator.GetAddress();
            Address address2 = generator.GetAddress();



            // Assert that two different calls to the method produce different addresses.
            Assert.AreNotEqual(address1, address2);
        }
    }
}