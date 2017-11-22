using System;
namespace Acute.Models
{
    public class UserProfile
    {
        public string Id
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string EmailAddress
        {
            get;
            set;
        }

        public UserProfile()
        {
        }

        public UserProfile(string id, string email)
        {
            Id = id;
            EmailAddress = email;
        }
    }

}
