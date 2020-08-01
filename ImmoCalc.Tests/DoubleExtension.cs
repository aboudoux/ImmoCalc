namespace ImmoCalc.Tests
{
	public static class DoubleExtension
	{
		public static double ToDouble(this string source) => double.Parse(source.Replace(".",","));
	}
}