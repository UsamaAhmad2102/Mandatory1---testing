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
        [DataRow("04", 2)]
        [DataRow("14", 2)]
        [DataRow("28", 2)]
        [DataRow("01", 2)]
        [DataRow("06", 3)]
        [DataRow("23", 3)]
        [DataRow("31", 3)]
        [DataRow("01", 3)]
        [DataRow("03", 4)]
        [DataRow("18", 4)]
        [DataRow("30", 4)]
        [DataRow("01", 4)]
        public void testBirthdayValidatorPositive(string birthday, int birthmonth) 
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthDay(birthday, birthmonth);

            Assert.IsTrue(isValid);


        }

        [TestMethod]
        [DataRow("00", 2)]
        [DataRow("29", 2)]
        [DataRow("1a", 2)]
        [DataRow("3", 2)]
        [DataRow("00", 3)]
        [DataRow("32", 3)]
        [DataRow("a4", 3)]
        [DataRow("6", 3)]
        [DataRow("31", 4)]
        [DataRow("00", 4)]
        [DataRow("4b", 4)]
        [DataRow("9", 4)]
        public void testBirthdayValidatorNegative(string birthday, int birthmonth)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthDay(birthday, birthmonth);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        [DataRow("01")]
        [DataRow("12")]
        [DataRow("06")]
        [DataRow("09")]
        public void TestBirthMonthValidatorPositive(string birthmonth)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthMonth(birthmonth);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        [DataRow("00")]
        [DataRow("13")]
        [DataRow("6")]
        [DataRow("3a")]
        [DataRow("aa")]
        [DataRow("120")]
        public void TestBirthMonthValidatorNegative(string birthmonth)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthMonth(birthmonth);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        [DataRow("00")]
        [DataRow("99")]
        [DataRow("01")]
        [DataRow("09")]
        [DataRow("50")]
        [DataRow("75")]
        [DataRow("25")]
        public void TestBirthYearValidatorPositive(string birthyear)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthYear(birthyear);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        [DataRow("4")]
        [DataRow("9")]
        [DataRow("100")]
        [DataRow("5a")]
        [DataRow("b2")]
        [DataRow("bw")]
        [DataRow(" 70")]
        public void TestBirthYearValidatorNegative(string birthyear)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthYear(birthyear);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        [DataRow("0101", "male")]
        [DataRow("3103", "male")]
        [DataRow("5819", "male")]
        [DataRow("0102", "female")]
        [DataRow("0104", "female")]
        [DataRow("0106", "female")]
        public void TestLastFourDigitsValidatorPositive(string cpr, string gender)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckLastFourDigits(cpr, gender);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        [DataRow("4")]
        [DataRow("9")]
        [DataRow("100")]
        [DataRow("5a")]
        [DataRow("b2")]
        [DataRow("bw")]
        [DataRow(" 70")]
        public void TestLastFourDigitsValidatorNegative(string digits)
        {
            CprValidator cprValidator = new();
            Boolean isValid = cprValidator.CheckDateOfBirthYear(digits);

            Assert.IsFalse(isValid);
        }













    }
}
