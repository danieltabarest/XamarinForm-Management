using System;
using System.Linq;
using System.Threading.Tasks;
using Acute.Data.Interfaces;
using Acute.Data.RealmModels;
using Realms;

namespace Acute.Data
{
	public static class EntityType
	{
		public static readonly string Announcement = "Announcement";
		public static readonly string Grade = "Grade";
	}

	public class ReadStatusRepository : IReadStatusRepository
    {
        private Realm _realm;

        public ReadStatusRepository()
        {
            _realm = Realm.GetInstance();
        }

        public async Task AddAsync(string id, string entityType)
        {
            if (!IsExists(id, entityType))
            {
				await _realm.WriteAsync(tempRealm =>
				{
                    var readStatus = new ReadStatus(id, entityType);
					tempRealm.Add(readStatus);
				});
            }
        }

        public bool IsExists(string id, string entity)
        {
            return _realm.All<ReadStatus>().Any(r => r.Id == id && r.EntityType == entity);
        }

        public void Reset()
        {
			using (var trans = _realm.BeginWrite())
			{
				_realm.RemoveAll<ReadStatus>();
				trans.Commit();
			}

        }
    }
}
