using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalTestDataGenerator.Validation;



namespace Mandatory1___testing.UnitTests
{
    [TestClass]
    public class CprValidatorUnitTest
    {
        [TestMethod]
        [DataRow("04", 2, 1970, true)]
        [DataRow("14", 2, 1970, true)]
        [DataRow("28", 2, 1970, true)]
        [DataRow("01", 2, 1970, true)]
        [DataRow("06", 3, 1970, true)]
        [DataRow("23", 3, 1970, true)]
        [DataRow("31", 3, 1970, true)]
        [DataRow("01", 3, 1970, true)]
        [DataRow("03", 4, 1970, true)]
        [DataRow("18", 4, 1970, true)]
        [DataRow("30", 4, 1970, true)]
        [DataRow("01", 4, 1970, true)]
        public void testBirthdayValidatorPositive(string birthday, int birthmonth, int birthyear) 
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthDay(birthday, birthmonth, birthyear);

            Assert.IsTrue(isValid);


        }

        [TestMethod]
        [DataRow("00", 2, 1970, false)]
        [DataRow("29", 2, 1970, false)]
        [DataRow("1a", 2, 1970, false)]
        [DataRow("3", 2, 1970, false)]
        [DataRow("00", 3, 1970, false)]
        [DataRow("32", 3, 1970, false)]
        [DataRow("a4", 3, 1970, false)]
        [DataRow("6", 3, 1970, false)]
        [DataRow("31", 4, 1970, false)]
        [DataRow("00", 4, 1970, false)]
        [DataRow("4b", 4, 1970, false)]
        [DataRow("9", 4, 1970, false)]
        public void testBirthdayValidatorNegative(string birthday, int birthmonth, int birthyear)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthDay(birthday, birthmonth, birthyear);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        [DataRow("01", true)]
        [DataRow("12", true)]
        [DataRow("06", true)]
        [DataRow("09", true)]
        public void TestBirthMonthValidatorPositive(string birthmonth)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthMonth(birthmonth);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        [DataRow("00", false)]
        [DataRow("13", false)]
        [DataRow("6", false)]
        [DataRow("3a", false)]
        [DataRow("aa", false)]
        [DataRow("120", false)]
        public void TestBirthMonthValidatorNegative(string birthmonth)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthMonth(birthmonth);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        [DataRow("00", true)]
        [DataRow("99", true)]
        [DataRow("01", true)]
        [DataRow("09", true)]
        [DataRow("50", true)]
        [DataRow("75", true)]
        [DataRow("25", true)]
        public void TestBirthYearValidatorPositive(string birthyear)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthYear(birthyear);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        [DataRow("4", false)]
        [DataRow("9", false)]
        [DataRow("100", false)]
        [DataRow("5a", false)]
        [DataRow("b2", false)]
        [DataRow("bw", false)]
        [DataRow(" 70", false)]
        public void TestBirthYearValidatorNegative(string birthyear)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthYear(birthyear);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        [DataRow("0101", "male", true)]
        [DataRow("3103", "male", true)]
        [DataRow("5819", "male", true)]
        [DataRow("0101", "female", true)]
        [DataRow("0101", "female", true)]
        [DataRow("0101", "female", true)]
        public void TestLastFourDigitsValidatorPositive(string cpr, string gender)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckLastFourDigits(cpr, gender);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        [DataRow("4", false)]
        [DataRow("9", false)]
        [DataRow("100", false)]
        [DataRow("5a", false)]
        [DataRow("b2", false)]
        [DataRow("bw", false)]
        [DataRow(" 70", false)]
        public void TestLastFourDigitsValidatorNegative(string digits)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthYear(digits);

            Assert.IsFalse(isValid);
        }













    }
}
