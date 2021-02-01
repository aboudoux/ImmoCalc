using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Domain;
using ImmoCalc.Infrastructures;
using MediatR;

namespace ImmoCalc.Stores.CurrentProject
{
	public class CurrentProjectReducer : ActionHandler<CurrentProjectState.ChangeValue>, 
		IRequestHandler<CurrentProjectState.IncludeChargesInMonthlyRent>,
		IRequestHandler<CurrentProjectState.IncludeNotaryFeesInLoadAmount>,
		IRequestHandler<CurrentProjectState.IncludeRenovationInLoadAmount>,
		IRequestHandler<CurrentProjectState.Load>,
		IRequestHandler<CurrentProjectState.CreateNewProject>
	{
		private readonly IProjectRepository _repository;
		private CurrentProjectState State => Store.GetState<CurrentProjectState>();

		public CurrentProjectReducer(IStore store, IProjectRepository repository) : base(store)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public override Task<Unit> Handle(CurrentProjectState.ChangeValue action, CancellationToken cancellationToken) {
			switch (action.Value) {
				case BuyingPrice v: State.Project.BuyingPrice = v; break;
				case MonthlyRent v: State.Project.MonthlyRent = v; break;
				case Charges v: State.Project.Charges = v.IncludedInMonthlyRent(State.Project.Charges.IsIncludedInMonthlyRent); break;
				case Surface v: State.Project.Surface = v; break;
				case PropertyTax v: State.Project.PropertyTax = v; break;
				case Renovation v: State.Project.Renovation = v.IncludedInLoanAmount(State.Project.Renovation.IsIncludedInLoadAmount); break;
				case LoanDuration v: State.Project.LoanDuration = v; break;
				case LoanRate v: State.Project.LoanRate = v; break;
				case InsuranceRate v: State.Project.InsuranceRate = v; break;
				case ProjectName v: State.Project.Name = v; break;
				case Address v: State.Project.Address = v; break;
			}
			State.Project.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(CurrentProjectState.IncludeChargesInMonthlyRent action, CancellationToken cancellationToken)
		{
			State.Project.Charges.IncludedInMonthlyRent(action.Include);
			State.Project.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(CurrentProjectState.IncludeNotaryFeesInLoadAmount action, CancellationToken cancellationToken)
		{
			State.Project.NotaryFees.IncludedInLoanAmount(action.Include);
			State.Project.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(CurrentProjectState.IncludeRenovationInLoadAmount action, CancellationToken cancellationToken)
		{
			State.Project.Renovation.IncludedInLoanAmount(action.Include);
			State.Project.Compute();
			return Unit.Task;
		}

		public async Task<Unit> Handle(CurrentProjectState.Load request, CancellationToken cancellationToken)
		{
			var project = await _repository.LoadProject(request.ProjectId.Value);
			State.Project = project;
			return Unit.Value;
		}

		public Task<Unit> Handle(CurrentProjectState.CreateNewProject request, CancellationToken cancellationToken)
		{
			State.Project = new Project(ProjectId.New);
			return Unit.Task;
		}
	}
}