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
				case BuyingPrice v: ChangeValue(a => a.BuyingPrice, v); break;
				case Surface v: ChangeValue(a=>a.Surface,v); break;

				case MonthlyRent v: ChangeValue(a => a.MonthlyRent, v); break;
				case Charges v: ChangeValue(a => a.Charges, v); break;

			}
			return Unit.Task;
		}

		private void ChangeValue(Expression<Func<InfosState, IValue>> member, IValue newValue) {

			var expression = (MemberExpression) member.Body;
			var name = expression.Member.Name;
			State.SetPropertyValue(name, newValue);
			State.Compute();
		}
	}
}