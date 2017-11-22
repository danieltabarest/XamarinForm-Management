using System;
using System.Linq;
using Acute.Data.Interfaces;
using Realms;

namespace Acute.Data
{
    public class ObjectCollectionCacheRepository<TDomain, TCache> : IObjectCollectionCacheRepository<TDomain>
    	where TDomain : class
		where TCache : RealmObject, Base.ICacheable<TDomain>
    {
        private readonly Realm _realm;

        public ObjectCollectionCacheRepository()
        {
            _realm = Realm.GetInstance();
        }

        public void Add(TDomain data, string key)
        {
			var cacheModel = (TCache)Activator.CreateInstance(typeof(TCache), new object[] { data, key });
			_realm.Write(() => _realm.Add(cacheModel));
        }

        public void ClearAll()
        {
            using (var trans = _realm.BeginWrite())
            {
                _realm.RemoveAll();
            }
        }

        public bool Exists(string key)
        {
            return _realm.All<TCache>().Any(e => e.Key == key);
        }

        public bool IsUpdateRequired()
        {
            var firstEntityFromDb = _realm.All<TCache>().FirstOrDefault();
            return firstEntityFromDb?.IsExpired ?? true;
        }

        public TDomain Retrieve(string key)
        {
            var entityFromDB = _realm.All<TCache>().FirstOrDefault( e => e.Key == key);
            return entityFromDB?.ToDomain();
        }
    }
}
