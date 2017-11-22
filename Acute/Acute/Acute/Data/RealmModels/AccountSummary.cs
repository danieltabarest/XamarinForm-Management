using System;
using Acute.Data.Base;
using Realms;

namespace Acute.Data.RealmModels
{
    public class AccountSummary : RealmObject, ICacheable<object>
    {
        public double Balance
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

        public AccountSummary()
        {
        }

  //      public AccountSummary(Models.AccountSummary domain, string key)
		//{
  //          //Update(domain, key);
		//}

        [Ignored]
        public bool IsExpired => DateTime.Now > CreationDate.DateTime.AddDays(1);

        //public void Update(Models.AccountSummary domain, string key)
        //{
        //    Balance = (double)domain.Balance;
        //    Key = key;
        //    CreationDate = new DateTimeOffset(DateTime.Now);
        //}

        //public Models.AccountSummary ToDomain()
        //{
        //    return new Models.AccountSummary((decimal)Balance);
        //}

        public bool IsKey(string candidate)
        {
            return candidate == Key;
        }

        public void Update(object domain, string key)
        {
            throw new NotImplementedException();
        }

        public object ToDomain()
        {
            throw new NotImplementedException();
        }
    }
}
