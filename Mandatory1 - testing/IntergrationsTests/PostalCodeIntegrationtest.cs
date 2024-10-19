//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using PersonalTestDataGenerator;

//namespace Mandatory1___testing.IntergrationsTests
//{
//    [TestClass]
//    public class PostalCodeIntegrationtest
//    {

//        public string connectionString = "Server=mandatorytestserver.mysql.database.azure.com;Port=3306;Database=addresses;User ID=admin123;Password=Password123;Charset=utf8;";

//        [TestMethod]
//        public void TestGeneratePostalandtown()
//        {
//            // Arrange
//            FakeInfoGenerator generator = new FakeInfoGenerator(connectionString);

//            // Act
//            generator.GeneratePostalandtown();

//            // Assert
//            // Check if postalcode and town properties are set
//            Assert.IsNotNull(generator.postalcode);
//            Assert.IsNotNull(generator.town);

//            // Check the format of postal code and town name
//            Assert.IsTrue(Regex.IsMatch(generator.postalcode, @"^\d{4}$"), "Postal code format is incorrect");
//            Assert.IsTrue(!string.IsNullOrEmpty(generator.town), "Town name should not be empty");

//            // Verify that the retrieved data exists in the database
//            using (MySqlConnection connection = new MySqlConnection(connectionString))
//            {
//                connection.Open();
//                using (MySqlCommand validationCmd = new MySqlCommand("SELECT COUNT(*) FROM postal_code WHERE cPostalCode = @PostalCode AND cTownName = @Town", connection))
//                {
//                    validationCmd.Parameters.AddWithValue("@PostalCode", generator.postalcode);
//                    validationCmd.Parameters.AddWithValue("@Town", generator.town);
//                    long count = (long)validationCmd.ExecuteScalar();
//                    Assert.AreEqual(1, count, "Postal code and town not found in the database");
//                }
//            }

           
//        }

//    }
//}
