using System;
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
	}
}