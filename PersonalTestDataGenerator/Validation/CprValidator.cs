using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalTestDataGenerator.Validation
{

    public class CprValidator
    {

        public bool CheckDateOfBirthDay(string birthday, int birthmonth)
        {
            Regex regex;

            if (birthmonth == 2)
            {
                regex = new Regex(@"^(0[1-9]|[1][0-9]|2[0-8])$");
            }
            else if (birthmonth % 2 == 0)
            {
                regex = new Regex(@"^(0[1-9]|[12][0-9]|30)$");
            }
            else
            {
                regex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])$");
            }

            return regex.IsMatch(birthday);

        }
        public bool CheckDateOfBirthMonth(string birthmonth)
        {
            Regex regex = new(@"^(0[1-9]|[1][0-2])$");

            return regex.IsMatch(birthmonth);
        }

        public bool CheckDateOfBirthYear(string birthyear)
        {
            Regex regex = new(@"^([0-9]{2})$"); ;

            return regex.IsMatch(birthyear);
        }


        public bool CheckLastFourDigits(string cpr, string gender)
        {
            Regex regex = new Regex(@"^\d{3}[1-9]$");
            bool isValid = false;

            if (regex.IsMatch(cpr))
            {
                char lastDigitChar = cpr[cpr.Length - 1];
                int lastDigitInt = lastDigitChar;

                if (lastDigitInt % 2 == 0 && gender.Equals("female"))
                {
                    isValid = true;
                }
                else if (lastDigitInt % 2 != 0 && gender.Equals("male"))
                {
                    isValid = true;
                }
            }
            return isValid;
        }


        public bool CheckFullCpr(string cpr)
        {
            Regex regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(cpr);
        }

    }
}

