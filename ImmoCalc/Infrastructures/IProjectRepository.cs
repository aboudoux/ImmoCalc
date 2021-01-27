using System;
using System.Threading.Tasks;

namespace ImmoCalc.Infrastructures 
{
	public interface IProjectRepository
	{
		Task<ProjectLabel[]> GetAllProjects();

		Task<FullProject> LoadProject(Guid projectId);
	}
}
