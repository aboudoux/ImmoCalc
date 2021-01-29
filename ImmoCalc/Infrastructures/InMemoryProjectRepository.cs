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
						new ProjectLabel(Guid.Empty, a.Name.Value, a.Address.Value))
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
	}
}