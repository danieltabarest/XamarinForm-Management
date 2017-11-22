using System;
namespace Acute.Models
{
        public class User
        {
            public string token { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public Companyinfo companyInfo { get; set; }

            public User(string _name)
            {
                firstName = _name;
            }
        }

        public class Companyinfo
        {
            public string name { get; set; }
        }

}
