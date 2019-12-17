using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class InputInaccessibleLocation
    {
        public static InaccessibleLocation WithInaccessibleLocation()
        {
            return new InaccessibleLocation(TestDataReader.GetTestData("InaccessibleStation"));
        }
    }
}
