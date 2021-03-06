using System;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Components.Converters
{
	public class RatioProperty<T> : EditableProperty<T>
		where T : class, IValue {
		public RatioConverter<T> Converter { get; }

		public RatioProperty(IMediator mediator, Func<double, T> factory, Func<T> retrieveFunc)
			: base(mediator, factory, retrieveFunc) {
			Converter = new RatioConverter<T>(factory);
		}
	}
}