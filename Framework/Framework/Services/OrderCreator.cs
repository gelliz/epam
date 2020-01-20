using System;
using Framework.Models;

namespace Framework.Services
{
    class OrderCreator
    {
        public static Location WithFilledFields()
        {
            return new Location(TestDataReader.GetTestData("PickUpLocation"), TestDataReader.GetTestData("ReturnLocation"));
        }

        public static InvalidPhoneNumber WithInvalidPhoneNumber()
        {
            return new InvalidPhoneNumber(TestDataReader.GetTestData("PhoneNumber"));
        }

        public static UserData WithLogIn()
        {
            return new UserData(TestDataReader.GetTestData("UserName"), TestDataReader.GetTestData("Password"));
        }
    }
}
