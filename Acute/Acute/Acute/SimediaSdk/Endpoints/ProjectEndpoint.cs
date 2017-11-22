using System;
using System.Threading.Tasks;
using RestSharp;
using Simedia.App.SDK.Models;
using Simedia.App.SDK.Models.Responses;
using Simedia.App.SDK.Shared;

namespace Simedia.App.SDK.Endpoints
{
    public class ProjectEndpoint : EndpointBase
    {
        public ProjectEndpoint(SimediaSDK sdk) 
            : base(sdk)
        {
        }

        public Task<ListResult<Project>> GetProjectsAsync(string searchString, int page, int page_size, string order_by = "", bool descending = false)
		{
            //var request = new RestRequest(Method.GET);
            //request.Resource = "Users/self";
            //return this.Sdk.ExecuteAsync<ListResult<Project>>(request);

            var val = Task.Run(() =>
            {
				ListResult<Project> projects = new ListResult<Project>();

				for (int i = 0; i < 5; i++)
				{
					Project prj = new Project();

					prj.Name = $"Project {i}";
					prj.Description = $"Description {i}";

					projects.items.Add(prj);
				}

				return projects;
            });

            return val;
		}
    }
}
