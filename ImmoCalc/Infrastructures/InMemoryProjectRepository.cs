using System;
using System.Threading.Tasks;
using ImmoCalc.Domain.Extensions;

namespace ImmoCalc.Infrastructures
{
	public class InMemoryProjectRepository : IProjectRepository
	{
		public async Task<ProjectLabel[]> GetAllProjects()
		{
			await Task.Delay(1.Seconds());
			return new[]
			{
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
				new ProjectLabel(Guid.NewGuid(), "Gorges de loup","22 rue de la fraternelle, 69009 LYON"),
				new ProjectLabel(Guid.NewGuid(), "Saint etienne","155b avenue antoine durafour, 42100 saint etienne"),
			};
		}

		public Task<FullProject> LoadProject(Guid projectId)
		{
			throw new NotImplementedException();
		}
	}
}