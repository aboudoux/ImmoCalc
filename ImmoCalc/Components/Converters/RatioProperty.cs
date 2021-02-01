using System;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Components.Converters
{
	public class RatioProperty<T> : EditableProperty<T, double>
		where T : class, IValue<double> {
		public RatioConverter<T> Converter { get; }

		public RatioProperty(IMediator mediator, Func<double, T> factory, Func<T> retrieveFunc)
			: base(mediator, factory, retrieveFunc) {
			Converter = new RatioConverter<T>(factory);
		}
	}
}