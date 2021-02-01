using System;
using System.Linq;
using ImmoCalc.Domain;
using ImmoCalc.Infrastructures;
using TechTalk.SpecFlow;

namespace ImmoCalc.Tests.Steps
{
	[Binding]
	public class Transformations
	{
		[StepArgumentTransformation]
		public ProjectLabel[] ToProjectLabel(Table table)
			=> table.Rows.Select(row => 
				new ProjectLabel(Guid.NewGuid(), row["Name"], row["Address"]))
				.ToArray();

		[StepArgumentTransformation]
		public (string testId, Project)[] ToProject(Table table)
			=> table.Rows.Select(row => (row["Id"],
				new Project(ProjectId.New)
				{
					Name = ProjectName.From(row["Name"]),
					Address = Address.From(row["Address"])
				}))
				.ToArray();
	}
}