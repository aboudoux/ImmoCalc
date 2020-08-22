using System.Threading;
using FluentAssertions;
using ImmoCalc.Stores.Infos;
using ImmoCalc.Tests.Tools;

namespace ImmoCalc.Tests.Assets {

	public class ComputedDataContext
	{
		public InfosState State { get; }
		public InfosReducer Reducer { get; }

		public ComputedDataContext()
		{
			State = new InfosState();
			State.Initialize();

			Reducer = new InfosReducer(new TestStore(State));
		}

		public void SetValue(string fieldName, double value) 
			=> ValueFactory.SetState(State, fieldName, value);

		public void ChangeValue(string fieldName, double value) 
			=> Reducer.Handle(new InfosState.ChangeValue(ValueFactory.Get(fieldName, value)), CancellationToken.None);

		public void ChangeRenovationInclude(bool isIncluded)
			=> Reducer.Handle(new InfosState.IncludeRenovationInLoadAmount(isIncluded), CancellationToken.None);

		public void ChangeNotaryFeesInclude(bool isIncluded)
			=> Reducer.Handle(new InfosState.IncludeNotaryFeesInLoadAmount(isIncluded), CancellationToken.None);

		public void ChangeChargesInclude(bool isIncluded)
			=> Reducer.Handle(new InfosState.IncludeChargesInMonthlyRent(isIncluded), CancellationToken.None);

		public void Assert(string fieldName, double value)
			=> ValueFactory.GetState(State, fieldName).Value.Should().Be(value);
	}
}