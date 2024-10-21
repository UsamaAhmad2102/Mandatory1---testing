using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalTestDataGenerator.Validation
{
    public class PhoneValidator
    {
        public bool ValidatePhoneNumberPrefix(string phoneNumber, string[] prefixes)
        {
            bool isValid = false;
            Regex regex = new(@"^\d{8}$");

            if (regex.IsMatch(phoneNumber))
            {
                foreach (string prefix in prefixes)
                {
                    if (phoneNumber.StartsWith(prefix))
                    {
                        isValid = true;
                        break;
                    }
                }

            }
            return isValid;
        }
    }
}
