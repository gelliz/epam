using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
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
