using System;

namespace Framework.Models
{
    public class InaccessibleLocation
    {
        public string InaccessibleStation { get; set; }
        public InaccessibleLocation(string inaccessibleStation)
        {
            InaccessibleStation = inaccessibleStation;
        }
    }
}
