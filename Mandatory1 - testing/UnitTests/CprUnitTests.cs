using PersonalTestDataGenerator.Models;
using PersonalTestDataGenerator;
using Newtonsoft.Json;

namespace Mandatory1___testing.UnitTests
{
    [TestClass]
    public class CprTests
    {
        private Random? random;

        [TestInitialize]
        public void Initialize()
        {
            random = new Random();
        }

        [TestMethod]
        public void SetBirthDateNotNull()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();
            DateTime result = generator.birthDate;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetBirthDateReturnDate()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();
            DateTime result = generator.birthDate;
            Assert.IsTrue(result >= new DateTime(1900, 1, 1) && result <= DateTime.Today);
        }

        [TestMethod]
        public void SetCprNotNull()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();
            DateTime date = generator.birthDate;
            string cpr = generator.cpr;


            Assert.IsNotNull(cpr);
        }

        [TestMethod]
        public void SetCpr10Digits()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();
            string result = generator.cpr;
            Assert.IsTrue(result.Length == 10);
        }

        [TestMethod]
        public void SetCprExpectedBirthdayPart()
        {
            DateTime birthdate = new DateTime(1990, 1, 1);
            string expected = "010190";
            FakeInfoGenerator generator = new FakeInfoGenerator();
            generator.birthDate = birthdate;
            generator.setCpr();
            string actual = generator.cpr.Substring(0, 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCprFemaleEvenNumber()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();
            generator.SetGender("female");
            generator.setBirthDate();
            generator.setCpr();

            int lastDigit = int.Parse(generator.cpr.Substring(9, 1));
            bool isFemale = lastDigit % 2 == 0;
            Assert.IsTrue(isFemale);
        }

        [TestMethod]
        public void SetCprMaleOddNumber()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();
            generator.SetGender("male");
            generator.setBirthDate();
            generator.setCpr();

            int lastDigit = int.Parse(generator.cpr.Substring(9, 1));
            bool isMale = lastDigit % 2 != 0;
            Assert.IsTrue(isMale);
        }

        [TestMethod]
        public void SetBirthDateRandomGeneration()
        {
            FakeInfoGenerator generator1 = new FakeInfoGenerator();
            FakeInfoGenerator generator2 = new FakeInfoGenerator();

            generator1.setBirthDate();
            generator2.setBirthDate();

            Assert.AreNotEqual(generator1.birthDate, generator2.birthDate);
        }

        [TestMethod]
        public void SetCprLeapYear()
        {
            FakeInfoGenerator generator = new FakeInfoGenerator();
            generator.birthDate = new DateTime(2000, 2, 29);
            generator.setCpr();

            string expectedBirthDatePart = "290200";
            string actualBirthDatePart = generator.cpr.Substring(0, 6);

            Assert.AreEqual(expectedBirthDatePart, actualBirthDatePart);
        }
    }
}