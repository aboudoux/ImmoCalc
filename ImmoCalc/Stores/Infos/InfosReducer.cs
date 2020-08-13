﻿using System.Threading;
using System.Threading.Tasks;
using BlazorState;
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
			State.BuyingPrice = action.BuyingPrice;
			return Unit.Task;
		}
	}
}