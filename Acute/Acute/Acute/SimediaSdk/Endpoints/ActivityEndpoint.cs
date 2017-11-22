using System;
using System.Threading.Tasks;
using Simedia.App.SDK.Models;

namespace Simedia.App.SDK.Endpoints
{
    public class ActivityEndpoint : EndpointBase
    {
		public ActivityEndpoint(SimediaSDK sdk) 
            : base(sdk)
        {
		}

		public Task<ListResult<Activity>> GetTasksAsync(string searchString, int page, int page_size, string order_by = "", bool descending = false)
		{
			//var request = new RestRequest(Method.GET);
			//request.Resource = "";
			//return this.Sdk.ExecuteAsync<ListResult<Activity>>(request);

			var val = Task.Run(() =>
			{
				ListResult<Activity> activities = new ListResult<Activity>();

				for (int i = 0; i < 5; i++)
				{
					Activity activity = new Activity();

					activity.name = $"Task {i}";
					activity.description = $"Description {i}";

					activities.items.Add(activity);
				}

				return activities;
			});

			return val;
		}
    }
}
