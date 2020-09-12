using System;
using ImmoCalc.Domain;
using ImmoCalc.Shared;

namespace ImmoCalc.Components.Converters
{
	public class RatioConverter<T> : IValueConverter
		where T : class, IValue 
	{
		private readonly Func<double, T> _factory;

		public RatioConverter(Func<double, T> factory) {
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
		}

		public object Convert(object value) {
			return !(value is T amount) || amount.Value == 0
				? string.Empty
				: Display.AsDecimal((amount.Value * 100).ToString()).ToString(2);
		}

		public object ConvertBack(object value) {
			var ratio = value as string;
			return string.IsNullOrWhiteSpace(ratio)
				? _factory(0)
				: _factory(double.Parse(ratio));
		}
	}
}