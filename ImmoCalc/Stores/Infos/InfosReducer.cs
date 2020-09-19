using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Stores.Infos
{
	public class InfosReducer : ActionHandler<InfosState.ChangeValue>, 
		IRequestHandler<InfosState.IncludeChargesInMonthlyRent>,
		IRequestHandler<InfosState.IncludeNotaryFeesInLoadAmount>,
		IRequestHandler<InfosState.IncludeRenovationInLoadAmount>
	{
		private InfosState State => Store.GetState<InfosState>();

		public InfosReducer(IStore store) : base(store)
		{
		}

		public override Task<Unit> Handle(InfosState.ChangeValue action, CancellationToken cancellationToken) {
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

		public Task<Unit> Handle(InfosState.IncludeChargesInMonthlyRent action, CancellationToken cancellationToken)
		{
			State.Charges.IncludedInMonthlyRent(action.Include);
			State.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(InfosState.IncludeNotaryFeesInLoadAmount action, CancellationToken cancellationToken)
		{
			State.NotaryFees.IncludedInLoanAmount(action.Include);
			State.Compute();
			return Unit.Task;
		}

		public Task<Unit> Handle(InfosState.IncludeRenovationInLoadAmount action, CancellationToken cancellationToken)
		{
			State.Renovation.IncludedInLoanAmount(action.Include);
			State.Compute();
			return Unit.Task;
		}
	}
}