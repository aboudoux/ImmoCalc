using System.Threading;
using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Stores.CurrentProject;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class InfosReducerShould
	{
		private readonly CurrentProjectState _state;

		private void ChangeValue<TValue>(TValue action) where TValue : IValue
		{
			var reducer = new CurrentProjectReducer(new TestStore(_state));
			reducer.Handle(new CurrentProjectState.ChangeValue(action), CancellationToken.None);
		}

		public InfosReducerShould()
		{
			_state = new CurrentProjectState();
			_state.Initialize();
		}

		[Fact]
		public void ChangeBuyingInformation()
		{
			ChangeValue(BuyingPrice.From(100000));

			_state.BuyingPrice.Value.Should().Be(100000);
			_state.NotaryFees.Value.Should().Be(7500);
		}

		[Fact]
		public void ChangeSurface()
		{
			_state.BuyingPrice = BuyingPrice.From(100000);
			
			ChangeValue(Surface.From(25));
			
			_state.Surface.Value.Should().Be(25);
			_state.SquareMeterPrice.Value.Should().Be(4000);
		}


		/*[Fact]
		public void ChangeMonthlyRent()
		{
			_state.BuyingPrice = BuyingPrice.From(139000);
			_state.MonthlyPayment = MonthlyPayment.Of(_state.BuyingPrice, LoanDuration.From(15), LoanRate.From(1.35));
			ChangeValue(MonthlyRent.From(800));
			
			_state.MonthlyRent.Value.Should().Be(800);
			//_state.Profitability.Value.Should().Be(0.0642);
			//_state.MonthlyGain.Value.Should().Be(-53);
		}*/

		/*[Fact]
		public void ChangeCharges()
		{
			_state.BuyingPrice = BuyingPrice.From(139000);
			_state.MonthlyPayment = MonthlyPayment.Of(_state.BuyingPrice, LoanDuration.From(15), LoanRate.From(1.35));
			_state.MonthlyRent = MonthlyRent.From(800);

			ChangeValue(Charges.From(80));

			_state.MonthlyGain.Value.Should().Be(-133);
			_state.Profitability.Value.Should().Be(0.0642);

		}*/
	}
}