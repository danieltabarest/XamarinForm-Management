using System;
namespace Acute.Data.Interfaces
{
    public interface IObjectCollectionCacheRepository<T> where T : class
    {
        void Add(T data, string key);
        T Retrieve(string key);
        bool Exists(string key);
        void ClearAll();
        bool IsUpdateRequired();
    }
}
