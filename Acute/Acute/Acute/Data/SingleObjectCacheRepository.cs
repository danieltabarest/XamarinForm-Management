﻿using System;
using System.Linq;
using Acute.Data.Interfaces;
using Realms;

namespace Acute.Data
{
    public class SingleObjectCacheRepository<TDomain, TCache> : ISingleObjectCacheRepository<TDomain>
        where TDomain : class
        where TCache : RealmObject, Base.ICacheable<TDomain>
    {
        private readonly Realm _realm;

        public SingleObjectCacheRepository()
        {
            _realm = Realm.GetInstance();
        }

        public TDomain Retrieve()
        {
            return FetchFromDb()?.ToDomain();
        }

		public void Update(TDomain data, string username)
		{
			if (IsEmpty())
				Create(data, username);
			else
				UpdateExisting(data, username);
		}

        public bool IsUpdateRequired(string key)
		{
			var dataFromDb = FetchFromDb();

			if (dataFromDb == null)
				return true;

            return dataFromDb.IsExpired || !dataFromDb.IsKey(key);
        }

        private void Create(TDomain domain, string key)
        {
            var cacheModel = (TCache)Activator.CreateInstance(typeof(TCache), new object[] { domain, key });
            _realm.Write(() => _realm.Add(cacheModel));
        }

        private void UpdateExisting(TDomain domain, string key)
		{
			var dataFromDb = FetchFromDb();

			using (var trans = _realm.BeginWrite())
			{
                dataFromDb.Update(domain, key);
				trans.Commit();
			}
		}

        private TCache FetchFromDb()
        {
            return _realm.All<TCache>().FirstOrDefault();
        }

		private bool IsEmpty()
		{
            return !_realm.All<TCache>().Any();
		}
    }
}
