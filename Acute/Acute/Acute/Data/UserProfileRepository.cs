using System;
using System.Threading.Tasks;
using Acute.Data.Base;
using Acute.Data.Interfaces;


using Acute.Models;

namespace Acute.Data
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IAPIContext _apiContext;

        public UserProfileRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<string> GetProfileImageAsync()
        {
            var uri = $"learning/UserData/user/image";
            var message = $"There was error while attempting to get profile image";

            return await _apiContext.GetResourceAsync(uri, message);

        }

        public Task<object> GetUserProfileAsync()
        {
            throw new NotImplementedException();
        }

        Task<object> IUserProfileRepository.GetUserProfileAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<UserProfile> GetUserProfileAsync()
        //{
        //    var uri = $"learning/UserData/user";
        //    var message = $"There was error while attempting to get user profile";

        //    return await _apiContext.GetResourceAsync<UserProfile, UserProfileDto>(uri, message);
        //}
    }
}
