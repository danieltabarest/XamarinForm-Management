using System;
namespace Simedia.App.SDK.Models.Request
{
    public class UserRequest : User
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
