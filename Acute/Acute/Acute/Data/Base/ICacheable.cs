using System;
namespace Acute.Data.Base
{
    public interface ICacheable<T> where T : class
    {
        DateTimeOffset CreationDate { get; set; }
        string Key { get; set; }
        bool IsExpired { get; }
        void Update(T domain, string key);
        T ToDomain();
        bool IsKey(string candidate);
    }
}
