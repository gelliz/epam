using System;
using System.Text;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class CreatingOrder
    {
       public static Location WithFilledFields()
       {
            return new Location(TestDataReader.GetTestData("PickUpLocation"), TestDataReader.GetTestData("ReturnLocation"));
       }
    }
}
