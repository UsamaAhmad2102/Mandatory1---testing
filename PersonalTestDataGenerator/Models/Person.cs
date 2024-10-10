

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace PersonalTestDataGenerator.Models

{

    public class personsData

    {

        public List<Person> Persons { get; set; }

    }

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


    public class postalsAndTownsData

    {

        public List<PostalAndTown> postalsAndTowns { get; set; } = new List<PostalAndTown>();



    }



    public class PostalAndTown

    {

        public string PostalCode { get; set; }

        public string Town { get; set; }

    }



    public class Address

    {

        public string Street { get; set; }

        public string Number { get; set; }

        public string Floor { get; set; }

        public string Door { get; set; }

        public string PostalCode { get; set; }

        public string Town { get; set; }

    }







}