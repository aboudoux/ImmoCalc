using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImmoCalc.Domain;

namespace ImmoCalc.Infrastructures
{
	public class InMemoryProjectRepository : IProjectRepository
	{
		private readonly List<Project> _projects = new List<Project>();

		public Task<ProjectLabel[]> GetAllProjects()
		{
			return Task.FromResult(
				_projects.Select(a =>
						new ProjectLabel(a.ProjectId.Value, a.Name.Value, a.Address.Value))
					.ToArray());
		}

		public Task<Project> LoadProject(Guid projectId)
		{
			return Task.FromResult(_projects.First());
		}

		public Task SaveProject(Project project)
		{
			_projects.Add(project);
			return Task.CompletedTask;
		}

		public Task Remove(ProjectId id)
		{
			var projectToRemove = _projects.FirstOrDefault(a => a.ProjectId.Value == id.Value);
			if (projectToRemove != null)
				_projects.Remove(projectToRemove);
			return Task.CompletedTask;
		}
	}
}