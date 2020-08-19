﻿using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Stores.Infos
{
	public class InfosReducer : 
		ActionHandler<InfosState.ChangeBuyingPrice>,
		IRequestHandler<InfosState.ChangeMonthlyRent>
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
			State.RateOfReturn = RateOfReturn.Of(State.BuyingPrice, action.MonthlyRent);
			return Unit.Task;
		}
	}
}