using Acute.Data.Base;
using Acute.Models;
using Acute.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acute.Dtos;

namespace Acute.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IAPIContext _apiContext;

        public ProjectRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }



        public async Task<Project> GetProjectAsync(string ProjectId)
        {
            var uri = $"learning/ProjectData/Project/Project/{ProjectId}";
            var message = $"There was an error while attempting to get the Project with id: {ProjectId}";

            return (await _apiContext.GetResourcesAsync<Project, ProjectDto>(uri, message)).FirstOrDefault();
        }

        public async Task<string> GetProjectNameAsync(string ProjectId)
        {
			var Project = await GetProjectAsync(ProjectId);
			return Project.data.type;
        }


        public async Task<IEnumerable<Project>> GetProjectsAsync(DateTime targetDate)
        {
            var uri = $"learning/ProjectData/Projectbydate?myDate={targetDate}";
            var message = $"There was an error while attempting to get the Projects for the target date: {targetDate}";

            return await _apiContext.GetResourcesAsync<Project, ProjectDto>(uri, message);
        }
    }
}
