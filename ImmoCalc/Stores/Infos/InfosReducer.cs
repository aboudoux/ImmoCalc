using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Domain;
using ImmoCalc.Shared;
using MediatR;

namespace ImmoCalc.Stores.Infos
{
	public class InfosReducer : ActionHandler<InfosState.ChangeBuyingPrice>
	{
		private InfosState State => Store.GetState<InfosState>();

		public InfosReducer(IStore store) : base(store)
		{
		}

		public override Task<Unit> Handle(InfosState.ChangeBuyingPrice action, CancellationToken cancellationToken)
		{
			State.BuyingPrice = Display.AsDecimal(action.BuyingPrice).ToString(0);

			var buyingPrice = BuyingPrice.From(action.BuyingPrice);
			var notaryFees = NotaryFees.Of(buyingPrice);

			State.NotaryFees = Display.AsDecimal(notaryFees.Value.ToString()).ToString(2);
			return Unit.Task;
		}
	}
}