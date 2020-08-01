using System.Globalization;
using System.Linq;
using WpfGridLayout.Blazor;

namespace ImmoCalc.Shared
{
	public class Display {
		private readonly string _value = string.Empty;
		private const string DecimalSeparator = ",";
		private static readonly CultureInfo FrCultureInfo = new CultureInfo("fr-FR");

		private Display(string value) {
			if (IsValid(value))
				_value = value ?? string.Empty;
		}

		public static Display AsDecimal(string value) => new Display(value);

		public override string ToString() => ToString(int.MaxValue);

		public string ToString(int maxDecimals) {
			if (!_value.Contains(DecimalSeparator))
				return FormatDecimal(_value, 0);

			var numberOfDecimals = _value.Split(DecimalSeparator).Last().Length;

			return FormatDecimal(_value, numberOfDecimals > maxDecimals
				? maxDecimals
				: numberOfDecimals) + (ShowSeparator() ? DecimalSeparator : string.Empty);

			bool ShowSeparator() => maxDecimals > 0 && numberOfDecimals == 0;
		}

		public static bool IsValid(string source)
			=> source.IsEmpty() || decimal.TryParse(source, out _);

		private static string FormatDecimal(string source, int numberOfDecimals)
			=> source.IsEmpty()
				? string.Empty
				: decimal.Parse(source).ToString("N" + numberOfDecimals, FrCultureInfo).Replace(" ", " ");
	}
}