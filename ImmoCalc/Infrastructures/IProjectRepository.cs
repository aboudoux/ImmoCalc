using System;
using System.Threading.Tasks;
using ImmoCalc.Domain;

namespace ImmoCalc.Infrastructures 
{
	public interface IProjectRepository
	{
		Task<ProjectLabel[]> GetAllProjects();

		Task<Project> LoadProject(Guid projectId);

		Task SaveProject(Project project);
	}
}
