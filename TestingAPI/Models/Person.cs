namespace PersonDataAPI.Models
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string CPR { get; set; } // 10-digit CPR with birthdate + 4 random digits
        public string Birthdate { get; set; }
        public string Address { get; set; } // Street, number, floor, door, postal code, town
        public string MobilePhoneNumber { get; set; }
    }
}
