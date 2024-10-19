using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalTestDataGenerator.Validation
{
    public class AddressValidator
    {

        public bool ValidateStreetNumber(string streetNumber)
        {
            Regex regex = new(@"^[1-9]\d{0,2}[a-zA-Z]?$");
            return regex.IsMatch(streetNumber);

        }

        public bool ValidateDoor(string floor)
        {
            Regex firstNamingConvention = new Regex(@"^((th|mf|tv)?([1-9]|[1234][0-9]|50))$");
            Regex secondNamingConvention = new Regex(@"^[a-z]-?[1-9]\d{0,2}$");
            Regex floorMatcher = new($@"^(({firstNamingConvention})|({secondNamingConvention}))$");

            return floorMatcher.IsMatch(floor);
        }

        public bool ValidateFloor(string floor)
        {
            Regex regex = new(@"^(st|[1-9]\d?)$");
            return regex.IsMatch(floor);

        }

        public bool ValidatePostalCode(string postalCode)
        {
            Regex regex = new(@"^\d{4}$");
            return regex.IsMatch(postalCode);
        }
    }
}
