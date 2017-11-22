using System;
using Newtonsoft.Json;

namespace MyLearn.Dtos
{
    [JsonObject]
    public class StaffDto
    {
        [JsonProperty]
        public string Name
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

        [JsonProperty]
        public string OfficeAddress
        {
            get;
            set;
        }

        [JsonProperty]
        public string OfficeHours
        {
            get;
            set;
        }

        [JsonProperty]
        public string Phone
        {
            get;
            set;
        }
    }
}
