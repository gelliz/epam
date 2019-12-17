using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    public class UserData
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserData(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
