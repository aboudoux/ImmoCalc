using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Domain;
using MediatR;
using TypeSupport.Extensions;

namespace ImmoCalc.Stores.Infos
{
	public class InfosReducer : ActionHandler<InfosState.ChangeValue>
	{
		private InfosState State => Store.GetState<InfosState>();

		public InfosReducer(IStore store) : base(store)
		{
		}

		public override Task<Unit> Handle(InfosState.ChangeValue action, CancellationToken cancellationToken) {
			switch (action.Value) {
				case BuyingPrice v: State.BuyingPrice = v; break;
				case Surface v: State.Surface = v; break;
				case MonthlyRent v: State.MonthlyRent = v; break;
				case Charges v: State.Charges = v; break;
				case Renovation v: State.Renovation = v.IncludedInLoanAmount(State.Renovation.IsIncludedInLoadAmount); break;
			}
			State.Compute();
			return Unit.Task;
		}
	}
}