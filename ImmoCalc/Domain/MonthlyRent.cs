namespace ImmoCalc.Domain
{
	public class MonthlyRent : ExactAmount
	{
		private MonthlyRent(double value) : base(value)
		{
		}

		public static MonthlyRent From(double value) => new MonthlyRent(value);
	}
}