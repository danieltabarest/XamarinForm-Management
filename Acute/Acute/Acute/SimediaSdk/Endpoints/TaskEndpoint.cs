using System;
using System.Threading.Tasks;
using Simedia.App.SDK.Models;

namespace Simedia.App.SDK.Endpoints
{
    public class TaskEndpoint : EndpointBase
    {
		public TaskEndpoint(SimediaSDK sdk) 
            : base(sdk)
        {
		}

		public Task<ListResult<TaskObject>> GetTasksAsync(string searchString, int page, int page_size, string order_by = "", bool descending = false)
		{
			//var request = new RestRequest(Method.GET);
			//request.Resource = "";
			//return this.Sdk.ExecuteAsync<ListResult<TaskObject>>(request);

			var val = Task.Run(() =>
			{
                ListResult<TaskObject> tasks = new ListResult<TaskObject>();

				for (int i = 1; i < 5; i++)
                {
                    TaskObject task = new TaskObject();

                    task.name = $"Task {i}";
                    task.description = $"Description {i}";

                    //task.Activities = AddActivities(i).items; 

                    tasks.items.Add(task);
                }

                return tasks;
			});

			return val;
		}

        private static ListResult<Activity> AddActivities (int i)
        {
            ListResult<Activity> activities = new ListResult<Activity>();
            for (int x = 0; x < i; x++)
            {
                Activity activity = new Activity();

                activity.name = $"Activity {x}";
                activity.description = $"Activity Description {x}";
                activity.Tasklogs = AddTasklogs(x).items;

                activities.items.Add(activity);
            }

            return activities;
        }

        private static ListResult<TaskLog> AddTasklogs(int i)
		{
			ListResult<TaskLog> tasklogs = new ListResult<TaskLog>();
			for (int x = 0; x < i; x++)
			{
				TaskLog tl = new TaskLog();

				tl.tasklog_id = x;
				tl.minutes = x * 10;
				tl.date = DateTime.Now;
				tl.comment = $"Comments {x}";
                tl.attachments = AddAttachments(x).items;

                tasklogs.items.Add(tl);
			}

            return tasklogs;
		}

        private static ListResult<Attachment> AddAttachments(int i)
		{
			ListResult<Attachment> attachments = new ListResult<Attachment>();
			for (int x = 0; x < i; x++)
			{
				Attachment att = new Attachment();

                att.name = $"Attachment name {x}";

				attachments.items.Add(att);
			}

            return attachments;
		}
    }
}
