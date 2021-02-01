using System;
using ImmoCalc.Domain;
using MediatR;

namespace ImmoCalc.Components.Converters
{
	public class StringProperty<T> : EditableProperty<T, string>
		where T : class , IValue<string> 
	{
		public StringValueConverter<T> Converter { get; }


		public StringProperty(IMediator mediator, Func<string, T> factory, Func<T> retrieveFunc) 
			: base(mediator, factory, retrieveFunc)
		{
			Converter = new StringValueConverter<T>(factory);
		}
	}
}