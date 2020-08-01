using ImmoCalc.Domains;

namespace ImmoCalc.Tests
{
	public class MonthlyRent : Amount
	{
		private MonthlyRent(double value) : base(value)
		{
		}

		public static MonthlyRent Of(Amount value) => new MonthlyRent(value.Value);
		public new static MonthlyRent Of(double value) => new MonthlyRent(value);
	}
}