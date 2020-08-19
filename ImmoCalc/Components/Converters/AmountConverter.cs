using System;
using ImmoCalc.Domain;
using ImmoCalc.Shared;

namespace ImmoCalc.Components.Converters
{
	public class AmountConverter<T> : IValueConverter 
		where T : class, IAmountValue
	{
		private readonly Func<double, T> _factory;

		public AmountConverter(Func<double, T> factory)
		{
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
		}

		public object Convert(object value)
		{
			return !(value is T amount) || amount.Value == 0
				? string.Empty
				: Display.AsDecimal(amount.Value.ToString()).ToString(2);
		}

		public object ConvertBack(object value)
		{
			var price = value as string;
			return string.IsNullOrWhiteSpace(price)
				? _factory(0)
				: _factory(double.Parse(price));
		}
	}
}