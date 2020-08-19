using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using BlazorState;
using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Stores.Infos;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class InfosReducerShould
	{
		private readonly InfosState _state;

		private void SendAction<TAction>(TAction action) where TAction : IAction
		{
			var reducer = new InfosReducer(new TestStore(_state));
			reducer
				.GetType()
				.GetMethods()
				.First(a => a.Name == "Handle" && a.GetParameters().First().ParameterType == typeof(TAction))
				.Invoke(reducer, new object?[]{ action, CancellationToken.None});
		}

		public InfosReducerShould()
		{
			_state = new InfosState();
		}

		[Fact]
		public void ChangeBuyingInformation()
		{
			SendAction(new InfosState.ChangeBuyingPrice(BuyingPrice.From(100000)));

			_state.BuyingPrice.Value.Should().Be(100000);
			_state.NotaryFees.Value.Should().Be(7500);
		}

		[Fact]
		public void ChangeMonthlyRent()
		{
			_state.BuyingPrice = BuyingPrice.From(139000);
			SendAction(new InfosState.ChangeMonthlyRent(MonthlyRent.From(800)));
			
			_state.MonthlyRent.Value.Should().Be(800);
			_state.RateOfReturn.Value.Should().Be(0.0642);
			// todo : modifier les autres infos impact� par le loyer mensuel
			// RateOfReturn, MonthlyGain
		}
	}
}