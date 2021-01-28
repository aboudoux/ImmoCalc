using System;
using BlazorState;
using ImmoCalc.Stores.CurrentProject;

namespace ImmoCalc.Tests.Tools
{
	public class TestStore : IStore
	{
		private readonly object _infoState;

		public TestStore(CurrentProjectState currentProjectState)
		{
			_infoState = currentProjectState ?? throw new ArgumentNullException(nameof(currentProjectState));
		}
		public TState GetState<TState>()
		{
			if(typeof(TState) !=  typeof(CurrentProjectState))
				throw new Exception();
			return (TState) _infoState;
		}

		public object GetState(Type aType)
		{
			throw new NotImplementedException();
		}

		public void SetState(IState aState)
		{
			throw new NotImplementedException();
		}

		public void Reset()
		{
			throw new NotImplementedException();
		}

		public Guid Guid { get; }
	}
}