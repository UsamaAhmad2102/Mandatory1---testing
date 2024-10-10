using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalTestDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory1___testing.Tests
{
    [TestClass()]
    public class PhoneGeneratorTests
    {
        [TestMethod]
        public void Return8Digits()
        {

            string phoneNumber = PhoneGenerator.GeneratePhoneNumber();

            //Om nummeret består af 8 cifre
            Assert.AreEqual(8, phoneNumber.Length);

        }

        [TestMethod]
        public void TheNumberShouldStartWith()
        {
            string phoneNumber = PhoneGenerator.GeneratePhoneNumber();

            //om den returne de valide numre
            Assert.IsTrue(PhoneGenerator.PhonePrefixes.Any(prefix => phoneNumber.StartsWith(prefix)));
        }
        [TestMethod]
        public void ShouldFailIfThereIsMoreThan8Numbers()
        {
          
                //generere et tilfædig telefonnummer
                string phoneNumber = PhoneGenerator.GeneratePhoneNumber();
                //tilføjer ekstra cifre
                string phoneNumberWithMoreThan8Digits = phoneNumber + "12345";

                //kaster en argumentException
                Assert.ThrowsException<ArgumentException>(() => PhoneGenerator.ValidatePhoneNumber(phoneNumberWithMoreThan8Digits));

                Console.WriteLine("Not a danish number");
            

        }
        [TestMethod]
        public void PhoneNumberShouldBeValid()
        {
            //her generere jeg et telefon nummer
            string phoneNumber = PhoneGenerator.GeneratePhoneNumber();

            //jeg sørger for at den har 8 cifre
            Assert.AreEqual(8, phoneNumber.Length);

            //Jeg sørger for at den har de gyldige prefixes
            Assert.IsTrue(PhoneGenerator.PhonePrefixes.Any(prefix => phoneNumber.StartsWith(prefix)));
        }
        [TestMethod]
        public void GenerateNumberWith1Digits()
        {
            //Vi opretter et gyldig digit fra prefixes 
            string[] oneDigitPrefixes = { "2", "3", "4", "5", "6", "7", "8", "9" };

            foreach (string prefix in oneDigitPrefixes)
            {
                string phoneNumber;
                //her tjekker vi om nummeret ikke starter med et af det ovenstående prefix og at den ikke har 8 cifre
                //det vil blive gentaget indtil begge er falske
                do
                {
                    phoneNumber = PhoneGenerator.GeneratePhoneNumber();
                }
                while (!phoneNumber.StartsWith(prefix) || phoneNumber.Length != 8);

                //Nummeret skal have 8 cifre og starte med et af digits fra ded ovenstående prefixes
                Assert.AreEqual(8, phoneNumber.Length);
                Assert.IsTrue(phoneNumber.StartsWith(prefix));
            }
        }
    }
}