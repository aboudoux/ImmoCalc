using System.Globalization;
using WpfGridLayout.Blazor;

namespace ImmoCalc.Domains
{
	public static class StringExtensions
	{
		private static readonly CultureInfo FrCultureInfo = new CultureInfo("fr-FR");
		public static string FormatDecimal(this string source, bool showCents = false) 
			=> decimal.Parse(source).ToString(showCents ? "N2" : "N0", FrCultureInfo).Replace(" "," ");

		public static bool IsValidDecimal(this string source)
		{
			return source.IsEmpty() || decimal.TryParse(source, out decimal result);
		}
	}
}