using System.Threading.Tasks;
using BlazorState;
using FluentAssertions;
using ImmoCalc.Infrastructures;
using ImmoCalc.Stores.CurrentProject;
using ImmoCalc.Stores.ProjectList;
using ImmoCalc.Tests.Tools;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ImmoCalc.Tests.Assets 
{

	public class IhmDataContext
	{
		public CurrentProjectState CurrentProjectState { get; }
		public ProjectListState ProjectListState { get; }
		private readonly IMediator _mediator;

		public IhmDataContext()
		{
			CurrentProjectState = new CurrentProjectState();
			ProjectListState = new ProjectListState();
			CurrentProjectState.Initialize();
			ProjectListState.Initialize();

			var store = new TestStore();
			store.AddState(CurrentProjectState);
			store.AddState(ProjectListState);

			IServiceCollection services = new ServiceCollection();
			services.AddMediatR(typeof(ProjectListReducer).Assembly);
			services.AddSingleton<IStore>(store);
			services.AddSingleton<IProjectRepository>(new InMemoryProjectRepository());

			var provider = services.BuildServiceProvider();
			_mediator = provider.GetService<IMediator>();
		}

		public async Task Send(IAction action) => await _mediator.Send(action);

		public void SetValue(string fieldName, double value)
			=> ValueFactory.SetState(CurrentProjectState, fieldName, value);

		public void ChangeValue(string fieldName, double value)
			=> _mediator.Send(new CurrentProjectState.ChangeValue(ValueFactory.Get(fieldName, value)));

		public void ChangeRenovationInclude(bool isIncluded)
			=> _mediator.Send(new CurrentProjectState.IncludeRenovationInLoadAmount(isIncluded));

		public void ChangeNotaryFeesInclude(bool isIncluded)
			=> _mediator.Send(new CurrentProjectState.IncludeNotaryFeesInLoadAmount(isIncluded));

		public void ChangeChargesInclude(bool isIncluded)
			=> _mediator.Send(new CurrentProjectState.IncludeChargesInMonthlyRent(isIncluded));

		public void Assert(string fieldName, double value)
			=> ValueFactory.GetState(CurrentProjectState, fieldName).Value.Should().Be(value);
	}
}