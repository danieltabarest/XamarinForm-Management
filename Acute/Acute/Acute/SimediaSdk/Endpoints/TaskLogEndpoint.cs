using System;
using System.Threading.Tasks;
using Simedia.App.SDK.Models;

namespace Simedia.App.SDK.Endpoints
{
    public class TaskLogEndpoint : EndpointBase
    {
		public TaskLogEndpoint(SimediaSDK sdk) 
            : base(sdk)
        {
		}

        public Task<ListResult<TaskLog>> GetTasksLogAsync(string searchString, int page, int page_size, string order_by = "", bool descending = false)
		{
			//var request = new RestRequest(Method.GET);
			//request.Resource = "Users/self";
			//return this.Sdk.ExecuteAsync<ListResult<Project>>(request);

			var val = Task.Run(() =>
			{
                ListResult<TaskLog> taskLogs = new ListResult<TaskLog>();

				for (int i = 0; i < 5; i++)
				{
                    TaskLog tl = new TaskLog();

                    tl.tasklog_id = i;
                    tl.minutes = i * 10;
                    tl.date = DateTime.Now;
                    tl.comment = $"Comments {i}";

					taskLogs.items.Add(tl);
			    }

                return taskLogs;
			});

			return val;
            
        }
    }
}
