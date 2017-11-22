using System;
namespace Acute.Models
{
    public class UserAccount
    {
        public string Username
        {
            get;
            set;
        }

        public string Company
        {
            get;
            set;
        }
        
        public string Password
        {
            get;
            set;
        }

        public UserAccount()
        {
        }

        public UserAccount(string username,string company)
        {
            Username = username;
            Company = company;
        }
        //public UserAccount(string username, string password)
        //{
        //    Username = username;
        //    Password = password;
        //}
    }
}
