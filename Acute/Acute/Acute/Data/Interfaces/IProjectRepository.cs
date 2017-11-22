using Acute.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acute.Data.Interfaces
{
	public interface IProjectRepository
	{
		Task<IEnumerable<Project>> GetProjectsAsync(DateTime targetDate);
		Task<Project> GetProjectAsync(string ProjectId);
        Task<string> GetProjectNameAsync(string ProjectId);
	}
}
