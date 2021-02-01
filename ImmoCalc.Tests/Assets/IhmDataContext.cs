using System.Threading.Tasks;
using BlazorState;
using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Infrastructures;
using ImmoCalc.Stores.CurrentProject;
using ImmoCalc.Stores.ProjectList;
using ImmoCalc.Tests.Tools;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow.EnvironmentAccess;

namespace ImmoCalc.Tests.Assets 
{

	public class IhmDataContext
	{
		public CurrentProjectState CurrentProjectState { get; }
		public ProjectListState ProjectListState { get; }

		public InMemoryProjectRepository Repository { get; }

		private readonly IMediator _mediator;

		public IhmDataContext()
		{
			CurrentProjectState = new CurrentProjectState();
			ProjectListState = new ProjectListState();
			CurrentProjectState.Initialize();
			ProjectListState.Initialize();

			Repository = new InMemoryProjectRepository();


			var store = new TestStore();
			store.AddState(CurrentProjectState);
			store.AddState(ProjectListState);

			IServiceCollection services = new ServiceCollection();
			services.AddMediatR(typeof(ProjectListReducer).Assembly);
			services.AddSingleton<IStore>(store);
			services.AddSingleton<IProjectRepository>(Repository);

			var provider = services.BuildServiceProvider();
			_mediator = provider.GetService<IMediator>();
		}

		public async Task Send(IAction action) => await _mediator.Send(action);

		public void SetValue(string fieldName, double value)
			=> ValueFactory.SetState(CurrentProjectState, fieldName, value);

		public void ChangeValue(string fieldName, double value)
			=> _mediator.Send(new CurrentProjectState.ChangeValue(ValueFactory.Get(fieldName, value)));
		
		public void ChangeValue(string fieldName, string value)
			=> _mediator.Send(new CurrentProjectState.ChangeValue(ValueFactory.Get(fieldName, value)));

		public void ChangeRenovationInclude(bool isIncluded)
			=> _mediator.Send(new CurrentProjectState.IncludeRenovationInLoadAmount(isIncluded));

		public void ChangeNotaryFeesInclude(bool isIncluded)
			=> _mediator.Send(new CurrentProjectState.IncludeNotaryFeesInLoadAmount(isIncluded));

		public void ChangeChargesInclude(bool isIncluded)
			=> _mediator.Send(new CurrentProjectState.IncludeChargesInMonthlyRent(isIncluded));

		public void CreateNewProject()
			=> _mediator.Send(new CurrentProjectState.CreateNewProject());

		public void RemoveProject(ProjectId id)
			=> _mediator.Send(new ProjectListState.RemoveProject(id));

		public void SaveCurrentProject()
			=> _mediator.Send(new CurrentProjectState.Save(CurrentProjectState.Project));

		public void LoadProject(ProjectId projectId)
			=> _mediator.Send(new CurrentProjectState.Load(projectId));

		public void Assert(string fieldName, double value)
			=> ((IValue<double>) ValueFactory.GetState(CurrentProjectState, fieldName)).Value.Should().Be(value);

		public void Assert(string fieldName, string value)
			=> ((IValue<string>) ValueFactory.GetState(CurrentProjectState, fieldName)).Value.Should().Be(value);
	}
}