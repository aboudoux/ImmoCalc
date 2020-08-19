using System;
using ImmoCalc.Domain;
using ImmoCalc.Shared;

namespace ImmoCalc.Components.Converters
{
	public class AmountToStringConverter : IValueConverter
	{
		public object Convert(object value)
		{
			var price = value as IAmountValue;
			return price.Value == 0 
				? string.Empty 
				: Display.AsDecimal(price.Value.ToString()).ToString(2);
		}

		public object ConvertBack(object value)
		{
			throw new NotImplementedException();
		}
	}
}