using System;
using PersonalTestDataGenerator;

namespace YourConsoleAppNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";

            while (userInput.ToLower() != "exit")
            {
                FakeInfoGenerator fakeInfoGenerator = new FakeInfoGenerator();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1: Return a fake CPR");
                Console.WriteLine("2: Return a fake full name and gender");
                Console.WriteLine("3: Return a fake full name, gender and date of birth");
                Console.WriteLine("4: Return a fake CPR, full name and gender");
                Console.WriteLine("5: Return a fake CPR, full name, gender and date of birth");
                Console.WriteLine("6: Return a fake address");
                Console.WriteLine("7: Return a fake mobile phone number");
                Console.WriteLine("8: Return all information for a fake person");
                Console.WriteLine("9: Return fake person information in bulk");
                Console.WriteLine("Type 'exit' to close the program");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine($"Fake CPR: {fakeInfoGenerator.GetCpr().cpr}");
                        break;
                    case "2":
                        var fullNameGender = fakeInfoGenerator.GetFullNameAndGender();
                        Console.WriteLine($"Full Name: {fullNameGender.FirstName} {fullNameGender.LastName}, Gender: {fullNameGender.Gender}");
                        break;
                    case "3":
                        var fullNameGenderDOB = fakeInfoGenerator.GetFullNameGenderDateOfBirth();
                        Console.WriteLine($"Full Name: {fullNameGenderDOB.FirstName} {fullNameGenderDOB.LastName}, Gender: {fullNameGenderDOB.Gender}, Date of Birth: {fullNameGenderDOB.birthDate}");
                        break;
                    case "4":
                        var cprFullNameGender = fakeInfoGenerator.GetCprFullNameGender();
                        Console.WriteLine($"CPR: {cprFullNameGender.cpr}, Full Name: {cprFullNameGender.FirstName} {cprFullNameGender.LastName}, Gender: {cprFullNameGender.Gender}");
                        break;
                    case "5":
                        var allPersonalInfo = fakeInfoGenerator.GetCprFullNameGenderDateOfBirth();
                        Console.WriteLine($"CPR: {allPersonalInfo.cpr}, Full Name: {allPersonalInfo.FirstName} {allPersonalInfo.LastName}, Gender: {allPersonalInfo.Gender}, Date of Birth: {allPersonalInfo.birthDate}");
                        break;
                    case "6":
                        var address = fakeInfoGenerator.GetAddress();
                        Console.WriteLine($"Address: {address.Street} {address.Number}, {address.Floor} {address.Door}, {address.PostalCode} {address.Town}");
                        break;
                    case "7":
                        Console.WriteLine($"Fake Phone Number: {fakeInfoGenerator.GetPhone().phone}");
                        break;
                    case "8":
                        var allInfo = fakeInfoGenerator.GetAllInformation();
                        Console.WriteLine($"Full Name: {allInfo.FirstName} {allInfo.LastName}, Gender: {allInfo.Gender}, Date of Birth: {allInfo.birthDate}, CPR: {allInfo.cpr}, Phone: {allInfo.phone}, Address: {allInfo.Address.Street} {allInfo.Address.Number}, {allInfo.Address.Floor} {allInfo.Address.Door}, {allInfo.Address.PostalCode} {allInfo.Address.Town}");
                        break;
                    case "9":
                        Console.WriteLine("Enter the number of fake persons to generate (between 2 and 100):");
                        if (int.TryParse(Console.ReadLine(), out int amount) && amount >= 2 && amount <= 100)
                        {
                            var fakePersons = fakeInfoGenerator.GetpersonsInformation(amount);
                            for (int i = 0; i < fakePersons.Persons.Count; i++)
                            {
                                var person = fakePersons.Persons[i];
                                Console.WriteLine($"Person {i + 1}: Full Name: {person.FirstName} {person.LastName}, Gender: {person.Gender}, Date of Birth: {person.birthDate}, CPR: {person.cpr}, Phone: {person.phone}, Address: {person.Address.Street} {person.Address.Number}, {person.Address.Floor} {person.Address.Door}, {person.Address.PostalCode} {person.Address.Town}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 2 and 100.");
                        }
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid number or type 'exit' to close the program.");
                        break;
                }
            }
        }
    }
}
