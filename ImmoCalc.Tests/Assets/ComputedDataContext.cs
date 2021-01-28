using System.Threading;
using FluentAssertions;
using ImmoCalc.Stores.CurrentProject;
using ImmoCalc.Tests.Tools;

namespace ImmoCalc.Tests.Assets {

	public class ComputedDataContext
	{
		public CurrentProjectState State { get; }
		public CurrentProjectReducer Reducer { get; }

		public ComputedDataContext()
		{
			State = new CurrentProjectState();
			State.Initialize();

			Reducer = new CurrentProjectReducer(new TestStore(State));
		}

		public void SetValue(string fieldName, double value) 
			=> ValueFactory.SetState(State, fieldName, value);

		public void ChangeValue(string fieldName, double value) 
			=> Reducer.Handle(new CurrentProjectState.ChangeValue(ValueFactory.Get(fieldName, value)), CancellationToken.None);

		public void ChangeRenovationInclude(bool isIncluded)
			=> Reducer.Handle(new CurrentProjectState.IncludeRenovationInLoadAmount(isIncluded), CancellationToken.None);

		public void ChangeNotaryFeesInclude(bool isIncluded)
			=> Reducer.Handle(new CurrentProjectState.IncludeNotaryFeesInLoadAmount(isIncluded), CancellationToken.None);

		public void ChangeChargesInclude(bool isIncluded)
			=> Reducer.Handle(new CurrentProjectState.IncludeChargesInMonthlyRent(isIncluded), CancellationToken.None);

		public void Assert(string fieldName, double value)
			=> ValueFactory.GetState(State, fieldName).Value.Should().Be(value);
	}
}