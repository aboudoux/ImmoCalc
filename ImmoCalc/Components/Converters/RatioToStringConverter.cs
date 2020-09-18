using System;
using ImmoCalc.Domain;
using ImmoCalc.Shared;

namespace ImmoCalc.Components.Converters
{
	public class RatioToStringConverter : IValueConverter
	{
		public object Convert(object value)
		{
			var ratio = value as IValue;
			return ratio.Value == 0
				? string.Empty
				: Display.AsDecimal((ratio.Value * 100).ToString()).ToString(2);
		}

		public object ConvertBack(object value)
		{
			throw new NotImplementedException();
		}
	}
}