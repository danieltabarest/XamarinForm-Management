using System;
using Acute.Data.Base;
using Realms;

namespace Acute.Data.RealmModels
{
    public class Term : RealmObject, ICacheable<object>
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

        public string Code
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool IsExpired
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Term()
        {
        }

        //public Term(Models.Term domain, string key)
        //{
        //    Update(domain, key);
        //}

        //[Ignored]
        //public bool IsExpired => DateTime.Now > CreationDate.DateTime.AddDays(30);

        //public bool IsKey(string candidate)
        //{
        //    return Key == candidate;
        //}

        //public Models.Term ToDomain()
        //{
        //    return new Models.Term
        //    {
        //        Code = Code,
        //        Description = Description
        //    };
        //}

        //public void Update(Models.Term domain, string key)
        //{
        //    Key = key;
        //    Code = domain.Code;
        //    Description = domain.Description;

        //    CreationDate = new DateTimeOffset(DateTime.Now);
        //}

        public void Update(object domain, string key)
        {
            throw new NotImplementedException();
        }

        object ICacheable<object>.ToDomain()
        {
            throw new NotImplementedException();
        }

        public bool IsKey(string candidate)
        {
            throw new NotImplementedException();
        }
    }
}
