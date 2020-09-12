using System;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Components.Converters
{
	public class AmountProperty<T> : EditableProperty<T>
		where T : class, IValue {
		public AmountConverter<T> Converter { get; }

		public AmountProperty(IMediator mediator, Func<double, T> factory, Func<T> retrieveFunc)
			: base(mediator, factory, retrieveFunc) {
			Converter = new AmountConverter<T>(factory);
		}
	}
}