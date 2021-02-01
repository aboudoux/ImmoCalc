using System.Threading;
using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Infrastructures;
using ImmoCalc.Stores.CurrentProject;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class CurrentProjectReducerShould
	{
		private readonly CurrentProjectState _state;

		private void ChangeValue<TValue>(TValue action) where TValue : IValueObject
		{
			var store = new TestStore();
			store.AddState(_state);
			var reducer = new CurrentProjectReducer(store, new InMemoryProjectRepository());
			reducer.Handle(new CurrentProjectState.ChangeValue(action), CancellationToken.None);
		}

		public CurrentProjectReducerShould()
		{
			_state = new CurrentProjectState();
			_state.Initialize();
		}

		[Fact]
		public void ChangeBuyingInformation()
		{
			ChangeValue(BuyingPrice.From(100000));

			_state.Project.BuyingPrice.Value.Should().Be(100000);
			_state.Project.NotaryFees.Value.Should().Be(7500);
		}

		[Fact]
		public void ChangeSurface()
		{
			_state.Project.BuyingPrice = BuyingPrice.From(100000);
			
			ChangeValue(Surface.From(25));
			
			_state.Project.Surface.Value.Should().Be(25);
			_state.Project.SquareMeterPrice.Value.Should().Be(4000);
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