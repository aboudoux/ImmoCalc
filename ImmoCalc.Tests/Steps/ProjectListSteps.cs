using System;
using System.Threading.Tasks;
using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Infrastructures;
using ImmoCalc.Stores.ProjectList;
using ImmoCalc.Tests.Assets;
using TechTalk.SpecFlow;
using TypeSupport.Extensions;

namespace ImmoCalc.Tests.Steps
{
	[Binding]
	public sealed class ProjectListSteps
	{
		private readonly IhmDataContext _context;
		private readonly ProjectIdMapping _mapping;

		public ProjectListSteps(IhmDataContext context, ProjectIdMapping mapping)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));
		}

		[Given(@"some projects stored in a database")]
		public async Task GivenSomeProjectsStoredInADatabase((string testId, Project project)[] data)
		{
			foreach (var entry in data)
			{
				await _context.Repository.SaveProject(entry.project);
				_mapping.Add(entry.testId, entry.project.ProjectId);
			}
		}

		[Given(@"I create a new project")]
		public void GivenICreateANewProject() 
			=> _context.CreateNewProject();

		[When(@"I remove the project (.*)")]
		public void WhenIRemoveTheProject(string projectId)
			=> _context.RemoveProject(_mapping.Get(projectId));


		[When(@"I save the project")]
		[Given(@"I save the project")]
		public void GivenISaveTheProject() 
			=> _context.SaveCurrentProject();

		[Given(@"I want to see the stored project")]
		[When(@"I want to see the stored project")]
		public async Task WhenIWantToSeeTheStoredProject()
		 => await _context.Send(new ProjectListState.LoadProjectList());
		

		[Then(@"the stored projects list is")]
		public void ThenTheStoredProjectsListIs(ProjectLabel[] expectedProjectList)
		{
			_context.ProjectListState.ProjectList.Should()
				.BeEquivalentTo(expectedProjectList, option =>
					option.Excluding(project => project.Id));
		}
	}
}