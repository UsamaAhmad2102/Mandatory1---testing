using Microsoft.Data.SqlClient;
using MongoDB.Driver.Core.Configuration;
using MySql.Data.MySqlClient;
using PersonDataAPI.Models;
using System;

namespace PersonDataAPI.Services
{
    public class MySqlService
    {
        private readonly string _connectionString;

        public MySqlService()
        {
            // Use your Azure SQL connection string
            _connectionString = "Server=tcp:schoolworkkea.database.windows.net,1433;Initial Catalog=TestingMandatory;Persist Security Info=False;User ID=younzable;Password=-+9?B'eW4Z-^DwM;TrustServerCertificate=False;Connection Timeout=60;";
            
        }

        // Method to save persons to SQL Server database
        public void SavePersonsToDatabase(List<Person> persons)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var person in persons)
                {
                    string query = "INSERT INTO Person (firstname, lastname, gender, CPR, dateOfBirth, Address, PhoneNumber) " +
                                   "VALUES (@Firstname, @Lastname, @Gender, @CPR, @Birthdate, @Address, @PhoneNumber)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Firstname", person.Firstname);
                        cmd.Parameters.AddWithValue("@Lastname", person.Lastname);
                        cmd.Parameters.AddWithValue("@Gender", person.Gender);
                        cmd.Parameters.AddWithValue("@CPR", person.CPR);
                        cmd.Parameters.AddWithValue("@Birthdate", person.Birthdate);
                        cmd.Parameters.AddWithValue("@Address", person.Address);
                        cmd.Parameters.AddWithValue("@PhoneNumber", person.MobilePhoneNumber);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Method to retrieve persons from the SQL Server database
        public List<Person> GetPersonsFromDatabase()
        {
            List<Person> persons = new List<Person>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Person";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person
                            {
                                Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                                Lastname = reader.GetString(reader.GetOrdinal("lastname")),
                                Gender = reader.GetString(reader.GetOrdinal("gender")),
                                CPR = reader.GetString(reader.GetOrdinal("CPR")),
                                Birthdate = reader.GetDateTime(reader.GetOrdinal("dateOfBirth")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                MobilePhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))
                            };

                            persons.Add(person);
                        }
                    }
                }
            }

            return persons;
        }
    }
}
