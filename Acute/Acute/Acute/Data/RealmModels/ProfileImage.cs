using System;
using Acute.Data.Base;
using Acute.Models;
using Realms;

namespace Acute.Data.RealmModels
{
    public class ProfileImage : RealmObject, ICacheable<string>
    {
		public string Base64ProfileImage
		{
			get;
			set;
		}

		public DateTimeOffset CreationDate
		{
			get;
			set;
		}

		public string Key
		{
			get;
			set;
		}

        public ProfileImage()
        {
        }

        //public ProfileImage(UserProfileImage domain, string key)
        //{
        //    Update(domain, key);
        //}

        [Ignored]
        public bool IsExpired => DateTime.Now > CreationDate.DateTime.AddDays(1);

        public bool IsKey(string candidate)
        {
            return candidate == Key;
		}

        //public void Update(UserProfileImage domain, string key)
        //{
        //    Base64ProfileImage = domain.Base64Image;
        //    Key = key;
        //    CreationDate = new DateTimeOffset(DateTime.Now);
        //}

        //public UserProfileImage ToDomain()
        //{
        //    return new UserProfileImage(Base64ProfileImage);
        //}

        public void Update(string domain, string key)
        {
            throw new NotImplementedException();
        }

        string ICacheable<string>.ToDomain()
        {
            throw new NotImplementedException();
        }
    }
}
