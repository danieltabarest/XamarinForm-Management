using System;
using MyLearn.Models;
using Newtonsoft.Json;

namespace MyLearn.Dtos
{
    [JsonObject]
    public class UserProfileDto : Data.Base.JsonObject<UserProfile>
    {
        [JsonProperty]
        public string NsuId
        {
            get;
            set;
        }

        [JsonProperty]
        public string UserName
        {
            get;
            set;
        }

        [JsonProperty]
        public string FullName
        {
            get;
            set;
        }

        [JsonProperty]
        public string EmailAddress
        {
            get;
            set;
        }

        public override UserProfile ToDomainModel()
        {
            return new UserProfile(NsuId, EmailAddress)
            {
                Username = UserName,
                Name = FullName
            };
        }
    }
}
