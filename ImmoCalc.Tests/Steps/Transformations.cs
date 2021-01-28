using System;
using System.Linq;
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
	}
}