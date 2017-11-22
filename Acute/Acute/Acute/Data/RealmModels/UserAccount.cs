using System;
using Acute.Data.Base;
using Realms;

namespace Acute.Data.RealmModels
{
    public class UserAccount : RealmObject, ICacheable<Models.UserAccount>
    {
        public string Key
        {
            get;
            set;
        }

        public DateTimeOffset CreationDate
        {
            get;
            set;
        }


        public string Company
        {
            get;
            set;
        }


        public string Username
        {
            get;
            set;
        }

        public UserAccount()
        {
        }

        public UserAccount(Models.UserAccount domain, string key)
        {
            Update(domain, key);
        }

        [Ignored]
        public bool IsExpired => DateTime.Now > CreationDate.DateTime.AddDays(1);

        public bool IsKey(string candidate)
        {
            return Key == candidate;
        }

        public Models.UserAccount ToDomain()
        {
            return new Models.UserAccount(Username, Company);
        }

        public void Update(Models.UserAccount domain, string key)
        {
            Key = key;
            Username = domain.Username;
            Company = domain.Company;
            CreationDate = new DateTimeOffset(DateTime.Now);
        }
    }
}
