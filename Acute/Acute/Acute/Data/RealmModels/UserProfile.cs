using System;
using Acute.Data.Base;
using Realms;

namespace Acute.Data.RealmModels
{
    public class UserProfile : RealmObject, ICacheable<Models.UserProfile>
    {
        public string Id
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

        public UserProfile()
        {
        }

        public UserProfile(Models.UserProfile domain, string key)
        {
            Update(domain, key);
        }

        [Ignored]
        public bool IsExpired => DateTime.Now > CreationDate.DateTime.AddDays(1);

        public bool IsKey(string candidate)
        {
            return candidate == Key;
        }

        public void Update(Models.UserProfile domain, string key)
        {
            Id = domain.Id;
            Name = domain.Name;
            EmailAddress = domain.EmailAddress;
            Key = key;

            CreationDate = new DateTimeOffset(DateTime.Now);
        }

        public Models.UserProfile ToDomain()
        {
            return new Models.UserProfile(Id, EmailAddress)
            {
                Name = Name
            };
        }
    }
}
