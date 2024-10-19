using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalTestDataGenerator.Validation;

namespace Mandatory1___testing.UnitTests
{
    [TestClass]
    public class AddressValidatorUnitTest
    {
        [TestMethod]
        [DataRow("140")]
        [DataRow("140a")]
        [DataRow("99")]
        [DataRow("99b")]
        [DataRow("10")]
        [DataRow("10c")]
        [DataRow("9")]
        [DataRow("9d")]
        public void TestStreetNumberValidatorPositive(string streetNumber)
        {
            AddressValidator addressValidator = new AddressValidator();
            bool isValid = addressValidator.ValidateStreetNumber(streetNumber);

            Assert.IsTrue(isValid);

        }

        [TestMethod]
        [DataRow("0")]
        [DataRow("1400")]
        [DataRow("01")]
        [DataRow("a")]
        [DataRow("ab")]
        [DataRow("abc")]
        [DataRow("abcd")]
        [DataRow("")]
        public void TestStreetNumberValidatorNegative(string streetNumber)
        {
            AddressValidator addressValidator = new AddressValidator();
            bool isValid = addressValidator.ValidateStreetNumber(streetNumber);

            Assert.IsFalse(isValid);

        }

        [TestMethod]
        [DataRow("st")]
        [DataRow("1")]
        [DataRow("50")]
        [DataRow("99")]
        public void TestFloorValidatorPositive(string floor)
        {
            AddressValidator addressValidator = new AddressValidator();
            bool isValid = addressValidator.ValidateFloor(floor);

            Assert.IsTrue(isValid);

        }

        [TestMethod]
        [DataRow("dt")]
        [DataRow("0")]
        [DataRow("100")]
        [DataRow("1a")]
        [DataRow("01")]
        [DataRow("")]
        public void TestFloorValidatorNegative(string floor)
        {
            AddressValidator addressValidator = new AddressValidator();
            bool isValid = addressValidator.ValidateFloor(floor);

            Assert.IsFalse(isValid);

        }

        [TestMethod]
        [DataRow("th1")]
        [DataRow("th50")]
        [DataRow("mf1")]
        [DataRow("mf50")]
        [DataRow("tv1")]
        [DataRow("tv50")]
        [DataRow("a1")]
        [DataRow("b20")]
        [DataRow("d100")]
        [DataRow("a-1")]
        [DataRow("b-50")]
        [DataRow("d-999")]
        public void TestDoorValidatorPositive(string door)
        {
            AddressValidator addressValidator = new AddressValidator();
            bool isValid = addressValidator.ValidateDoor(door);

            Assert.IsTrue(isValid);

        }

        [TestMethod]
        [DataRow("th")]
        [DataRow("mf")]
        [DataRow("tv")]
        [DataRow("tm")]
        [DataRow("th0")]
        [DataRow("th1000")]
        [DataRow("mf0")]
        [DataRow("mf1000")]
        [DataRow("tv0")]
        [DataRow("tv1000")]
        [DataRow("t")]
        [DataRow("a01")]
        [DataRow("a1000")]
        [DataRow("a/1")]
        [DataRow("")]
        public void TestDoorValidatorNegative(string door)
        {
            AddressValidator addressValidator = new AddressValidator();
            bool isValid = addressValidator.ValidateDoor(door);

            Assert.IsFalse(isValid);

        }

    }
}
