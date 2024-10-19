//using Newtonsoft.Json;
//using PersonalTestDataGenerator;
//using PersonalTestDataGenerator.Models;
//using PersonalTestDataGenerator;


//namespace Mandatory1___testing.IntergrationsTests
//{
//    [TestClass]
//    public class SetFullNameAndGenderIntergrationsTest
//    {

//        //Test for SetFullNameAndGender() what happens if the json file is invalid.
//        [TestMethod]
//        [ExpectedException(typeof(JsonReaderException))]
//        public void TestSetFullNameAndGenderInvalidJsonJsonReaderException()
//        {
//            var generator = new FakeInfoGenerator();
//            File.WriteAllText("Invalid.json", "{ invalid json }");
//            generator.jsonFilePath = "Invalid.json";
//            generator.SetFullNameAndGender();
//        }
//        //Test SetFullNameAndGender() What happens when the json file does not exist.
//        [TestMethod]
//        [ExpectedException(typeof(FileNotFoundException))]
//        public void SetFullNameAndGenderNonExistentFileJsonFileNotFoundException()
//        {
//            var generator = new FakeInfoGenerator();
//            generator.jsonFilePath = "NonExistentFile.json";
//            generator.SetFullNameAndGender();
//        }
//        //Test SetFullNameAndGender() What happens when the json file is empty.
//        [TestMethod]
//        [ExpectedException(typeof(InvalidOperationException))]
//        public void TestSetFullNameAndGenderEmptyPersonsInvalidOperationException()
//        {
//            var generator = new FakeInfoGenerator();
//            File.WriteAllText("EmptyPersons.json", "{ \"Persons\": [] }");
//            generator.jsonFilePath = "EmptyPersons.json";
//            generator.SetFullNameAndGender();
//        }
//    }
//}