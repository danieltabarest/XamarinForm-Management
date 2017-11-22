using System;
using System.Threading.Tasks;
using RestSharp;
using Simedia.App.SDK.Models;
using Simedia.App.SDK.Models.Responses;
using Simedia.App.SDK.Shared;

namespace Simedia.App.SDK.Endpoints
{
    public class UserEndpoint : EndpointBase
    {
        public UserEndpoint(SimediaSDK sdk)
            : base(sdk)
        {

        }

        public Task<ItemResult<UserResponse>> GetUserAsync(string username, string password)
        {
			//var request = new RestRequest(Method.POST);
			//request.Resource = "WS/1/session";
   //         request.AddParameter("email", username);
   //         request.AddParameter("password", password);
			//return this.Sdk.ExecuteAsync<ItemResult<UserResponse>>(request);

			//var request = new RestRequest(Method.GET);
			//request.Resource = "posts/1";			
			//return this.Sdk.ExecuteAsync<ItemResult<UserResponse>>(request);

			var val = Task.Run(() =>
			{
				ItemResult<UserResponse> testUser = new ItemResult<UserResponse>();

                if (username.ToUpper() == "IGOR")
                {
					if (password == "123")
					{
						testUser = TestUserMethod();
					}
					else
					{
						testUser.success = false;
						testUser.message = "Wrong password...";
						return testUser;
					}
                }
                else
                {
                    testUser.success = false;
                    testUser.message = "User cant be found...";
                    return testUser; 
                }

				return testUser;
			});

            Task.Delay(3000);

			return val;			
        }

        public Task<ItemResult<UserResponse>> GetUserByIdAsync(Guid userId)
        {
			//var request = new RestRequest(Method.GET);
			//request.Resource = "Users/user_id";
   //         request.AddParameter("user_id", userId);	         
			//return this.Sdk.ExecuteAsync<ItemResult<UserResponse>>(request);

			var val = Task.Run(() =>
			{
				ItemResult<UserResponse> testUser = new ItemResult<UserResponse>();				
				testUser = TestUserMethod();				

				return testUser;
			});

			Task.Delay(3000);

			return val;
		}

        protected ItemResult<UserResponse> TestUserMethod()
        {
            ItemResult<UserResponse> testUser = new ItemResult<UserResponse>();
            testUser.item = new UserResponse();
			testUser.item.user_id = Guid.NewGuid();
			testUser.item.FirstName = "Sebastian";
			testUser.item.LastName = "Greco";
			testUser.item.Token = "1234567890";
            testUser.success = true;
			testUser.item.MyCompany = new Company()
			{
				Name = "Test company",
				FirstOpenFiscalDay = DateTime.Now
			};
            return testUser;
        }
    }
}
