using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Stores.CurrentProject
{
	public class CurrentProjectReducer : ActionHandler<CurrentProjectState.ChangeValue>, 
		IRequestHandler<CurrentProjectState.IncludeChargesInMonthlyRent>,
		IRequestHandler<CurrentProjectState.IncludeNotaryFeesInLoadAmount>,
		IRequestHandler<CurrentProjectState.IncludeRenovationInLoadAmount>
	{
		private CurrentProjectState State => Store.GetState<CurrentProjectState>();

		public CurrentProjectReducer(IStore store) : base(store)
		{
		}

		public override Task<Unit> Handle(CurrentProjectState.ChangeValue action, CancellationToken cancellationToken) {
			switch (action.Value) {
				case BuyingPrice v: State.BuyingPrice = v; break;
				case MonthlyRent v: State.MonthlyRent = v; break;
				case Charges v: State.Charges = v.IncludedInMonthlyRent(State.Charges.IsIncludedInMonthlyRent); break;
				case Surface v: State.Surface = v; break;
				case PropertyTax v: State.PropertyTax = v; break;
				case Renovation v: State.Renovation = v.IncludedInLoanAmount(State.Renovation.IsIncludedInLoadAmount); break;
				case LoanDuration v: State.LoanDuration = v; break;
				case LoanRate v: State.LoanRate = v; break;
				case InsuranceRate v: State.InsuranceRate = v; break;
			}
			State.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(CurrentProjectState.IncludeChargesInMonthlyRent action, CancellationToken cancellationToken)
		{
			State.Charges.IncludedInMonthlyRent(action.Include);
			State.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(CurrentProjectState.IncludeNotaryFeesInLoadAmount action, CancellationToken cancellationToken)
		{
			State.NotaryFees.IncludedInLoanAmount(action.Include);
			State.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(CurrentProjectState.IncludeRenovationInLoadAmount action, CancellationToken cancellationToken)
		{
			State.Renovation.IncludedInLoanAmount(action.Include);
			State.Compute();
			return Unit.Task;
		}
	}
}