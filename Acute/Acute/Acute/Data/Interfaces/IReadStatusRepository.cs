using System;
using System.Threading.Tasks;

namespace Acute.Data.Interfaces
{
    public interface IReadStatusRepository
    {
        Task AddAsync(string id, string entity);
        bool IsExists(string id, string entity);
        void Reset();
    }
}
