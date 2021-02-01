using System;
using ImmoCalc.Domain;

namespace ImmoCalc.Components.Converters
{
	public class StringValueConverter<T> : IValueConverter
		where T : IValue<string>
	{
		private readonly Func<string, T> _factory;

		public StringValueConverter(Func<string, T> factory)
		{
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
		}

		public object Convert(object value)
		{
			var data = value as IValue<string>;
			return data.Value;
		}

		public object ConvertBack(object value)
		{
			var data = value as string;
			return _factory(data);
		}
	}
}