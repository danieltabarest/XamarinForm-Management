using System;
using System.Threading.Tasks;
using Acute.Models;

namespace Acute.Data.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<object> GetUserProfileAsync();
        Task<string> GetProfileImageAsync();
    }
}
