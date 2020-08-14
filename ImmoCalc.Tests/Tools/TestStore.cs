using System;
using BlazorState;
using ImmoCalc.Stores.Infos;

namespace ImmoCalc.Tests.Tools
{
	public class TestStore : IStore
	{
		private readonly object _infoState;

		public TestStore(InfosState infoState)
		{
			_infoState = infoState ?? throw new ArgumentNullException(nameof(infoState));
		}
		public TState GetState<TState>()
		{
			if(typeof(TState) !=  typeof(InfosState))
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