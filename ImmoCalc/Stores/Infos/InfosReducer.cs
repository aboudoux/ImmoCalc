using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Stores.Infos
{
	public class InfosReducer : 
		ActionHandler<InfosState.ChangeBuyingPrice>,
		IRequestHandler<InfosState.ChangeMonthlyRent>,
		IRequestHandler<InfosState.ChangeCharges>
	{
		private InfosState State => Store.GetState<InfosState>();

		public InfosReducer(IStore store) : base(store)
		{
		}

		public override Task<Unit> Handle(InfosState.ChangeBuyingPrice action, CancellationToken cancellationToken)
		{
			State.BuyingPrice = action.BuyingPrice;
			State.NotaryFees = NotaryFees.Of(action.BuyingPrice);
			return Unit.Task;
		}

		public Task<Unit> Handle(InfosState.ChangeMonthlyRent action, CancellationToken cancellationToken)
		{
			State.MonthlyRent = action.MonthlyRent;
			//State.Profitability = Profitability.Of(State.BuyingPrice, action.MonthlyRent); // todo : ajouter les charges
			return Unit.Task;
		}

		public Task<Unit> Handle(InfosState.ChangeCharges action, CancellationToken cancellationToken)
		{
			State.Charges = action.Charges;
			
			return Unit.Task;
		}
	}
}