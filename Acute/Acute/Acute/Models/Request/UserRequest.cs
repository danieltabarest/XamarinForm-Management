using System;
namespace Acute.Models.Request
{
    public class UserRequest : User
    {
        public UserRequest(string name) : base(name)
        {
        }

        public string email { get; set; }
        public string password { get; set; }
    }
}
