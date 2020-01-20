using System;

namespace Framework.Models
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
