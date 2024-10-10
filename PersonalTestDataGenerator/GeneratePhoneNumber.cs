using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalTestDataGenerator;

namespace PersonalTestDataGenerator
{
    public class PhoneGenerator
    {
        public static string[] PhonePrefixes = new string[]
        {
        "2", "30", "31", "40", "41", "42", "50", "51", "52", "53", "60", "61", "71", "81", "91", "92", "93",
        "342", "344", "345", "346", "347", "348", "349", "356", "357", "359", "362", "365", "366", "389",
        "398", "431", "441", "462", "466", "468", "472", "474", "476", "478", "485", "486", "488", "489",
        "493", "494", "495", "496", "498", "499", "542", "543", "545", "551", "552", "556", "571", "572",
        "573", "574", "577", "579", "584", "586", "587", "589", "597", "598", "627", "629", "641", "649",
        "658", "662", "663", "664", "665", "667", "692", "693", "694", "697", "771", "772", "782", "783",
        "785", "786", "788", "789", "826", "827", "829"
        };

        public static string GeneratePhoneNumber()
        {
            Random random = new Random();
            string prefix = PhonePrefixes[random.Next(PhonePrefixes.Length)];
            string phoneNumber = prefix;

            for (int i = 0; i < 8 - prefix.Length; i++)
            {
                phoneNumber += random.Next(10).ToString();
            }


            return phoneNumber;
        }
        public static void ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length > 8)
            {
                throw new ArgumentException("No, that is not a Danish number");
            }
        }
    }
}