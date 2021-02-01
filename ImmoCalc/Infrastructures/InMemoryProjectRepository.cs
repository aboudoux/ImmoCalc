using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImmoCalc.Domain;

namespace ImmoCalc.Infrastructures
{
	public class InMemoryProjectRepository : IProjectRepository
	{
		private readonly Dictionary<Guid, Project> _projects = new Dictionary<Guid, Project>();
		
		public Task<ProjectLabel[]> GetAllProjects()
		{
			return Task.FromResult(
				_projects.Values.Select(a =>
						new ProjectLabel(a.ProjectId.Value, a.Name.Value, a.Address.Value))
					.ToArray());
		}

		public Task<Project> LoadProject(Guid projectId)
		{
			if(!_projects.ContainsKey(projectId))
				throw new Exception("project not found");
			return Task.FromResult(_projects[projectId]);
		}

		public Task SaveProject(Project project)
		{
			if(!_projects.ContainsKey(project.ProjectId.Value))
				_projects.Add(project.ProjectId.Value, project);
			else
				_projects[project.ProjectId.Value] = project;
			
			return Task.CompletedTask;
		}

		public Task Remove(ProjectId id)
		{
			if (_projects.ContainsKey(id.Value))
				_projects.Remove(id.Value);
			return Task.CompletedTask;
		}
	}
}