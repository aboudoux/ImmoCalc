using System;
using System.Threading.Tasks;
using FluentAssertions;
using ImmoCalc.Infrastructures;
using ImmoCalc.Stores.ProjectList;
using ImmoCalc.Tests.Assets;
using TechTalk.SpecFlow;

namespace ImmoCalc.Tests.Steps
{
	[Binding]
	public sealed class StoredProjectSteps
	{
		private readonly IhmDataContext _context;

		public StoredProjectSteps(IhmDataContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}
		[Given(@"some projects stored in a database")]
		public void GivenSomeProjectsStoredInADatabase(Table table) 
		{
			
		}

		[When(@"I want to see the stored project")]
		public async Task WhenIWantToSeeTheStoredProject()
		{
			await _context.Send(new ProjectListState.LoadProjectList());
		}

		[Then(@"the stored projects list is")]
		public void ThenTheStoredProjectsListIs(ProjectLabel[] expectedProjectList)
		{
			_context.ProjectListState.ProjectList.Should()
				.BeEquivalentTo(expectedProjectList, option =>
					option.Excluding(project => project.Id));
		}
	}
}