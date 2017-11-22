using System;
namespace Simedia.App.SDK.Models
{
    public class User : BaseModel
    {
        public Guid user_id
        {
            get;
            set;
        }

		public string FirstName
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public Company MyCompany
		{
			get;
			set;
		}

		public string Token
		{
			get;
			set;
		}

        public string api_secret { get; set; }
        public string api_key { get; set; }
        public string api_enabled { get; set; }
    }
}
