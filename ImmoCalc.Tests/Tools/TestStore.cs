using System;
using System.Collections.Generic;
using BlazorState;
using ImmoCalc.Stores.CurrentProject;

namespace ImmoCalc.Tests.Tools
{
	public class TestStore : IStore
	{
		private readonly Dictionary<Type, object> _states = new Dictionary<Type, object>();

		public void AddState<TState>(TState state)
		{
			_states.Add(typeof(TState), state);
		}

		public TState GetState<TState>()
		{
			var stateTye = typeof(TState);
			if(!_states.ContainsKey(stateTye))
				throw new Exception("state not found");

			return (TState)_states[stateTye];
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