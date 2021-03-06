using System;
using ImmoCalc.Domain;
using ImmoCalc.Stores.Infos;
using MediatR;

namespace ImmoCalc.Components.Converters
{
	public abstract class EditableProperty<T> where T : class, IValue {
		private readonly IMediator _mediator;
		private readonly Func<T> _retrieveFunc;

		protected EditableProperty(IMediator mediator, Func<double, T> factory, Func<T> retrieveFunc) {
			if (factory == null) throw new ArgumentNullException(nameof(factory));
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
			_retrieveFunc = retrieveFunc;
		}

		public T Value
		{
			get => _retrieveFunc();
			set => _mediator.Send(new InfosState.ChangeValue(value));
		}
	}
}