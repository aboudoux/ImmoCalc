using System;
using ImmoCalc.Domain;
using ImmoCalc.Stores.CurrentProject;
using MediatR;

namespace ImmoCalc.Components.Converters
{
	public abstract class EditableProperty<T,U> where T : class, IValueObject {
		private readonly IMediator _mediator;
		private readonly Func<T> _retrieveFunc;

		protected EditableProperty(IMediator mediator, Func<U, T> factory, Func<T> retrieveFunc) {
			if (factory == null) throw new ArgumentNullException(nameof(factory));
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
			_retrieveFunc = retrieveFunc;
		}

		public T Value
		{
			get => _retrieveFunc();
			set => _mediator.Send(new CurrentProjectState.ChangeValue(value));
		}
	}
}