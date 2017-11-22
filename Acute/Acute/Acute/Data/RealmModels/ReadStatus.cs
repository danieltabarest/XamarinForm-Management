using System;
using Realms;

namespace Acute.Data.RealmModels
{
    public class ReadStatus : RealmObject
    {
        [PrimaryKey]
        public string Id
        {
            get;
            set;
        }

        public string EntityType
        {
            get;
            set;
        }

        public DateTimeOffset Created
        {
            get;
            set;
        }

        public ReadStatus()
        {
        }

        public ReadStatus(string id, string entityType)
        {
            Id = id;
            EntityType = entityType;
            Created = DateTimeOffset.Now;
        }
    }
}
