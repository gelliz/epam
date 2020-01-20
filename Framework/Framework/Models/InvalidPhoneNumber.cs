using System;

namespace Framework.Models
{
    public class InvalidPhoneNumber
    {
        public string PhoneNumber { get; set; }
        public InvalidPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
