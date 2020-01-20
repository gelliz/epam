using System;

namespace Framework.Models
{
    public class Location
    {
        public string PickUpLocation { get; set; }
        public string ReturnLocation { get; set; }
        public Location(string pickUpPlace, string returnPlace)
        {
            PickUpLocation = pickUpPlace;
            ReturnLocation = returnPlace;
        }
    }
}
