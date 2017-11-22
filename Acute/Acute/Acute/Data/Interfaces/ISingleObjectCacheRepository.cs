using System;
using Acute.Data.RealmModels;

namespace Acute.Data.Interfaces
{
    public interface ISingleObjectCacheRepository<T> where T : class
    {
		void Update(T data, string username);
		T Retrieve();
		bool IsUpdateRequired(string username);
    }
}
