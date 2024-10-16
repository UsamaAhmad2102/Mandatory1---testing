

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PersonalTestDataGenerator.Models

{

    public class Person
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public DateTime? birthDate { get; set; }

        public string? cpr { get; set; }

        public string? phone { get; set; }

        public Address? Address { get; set; }


    }

}