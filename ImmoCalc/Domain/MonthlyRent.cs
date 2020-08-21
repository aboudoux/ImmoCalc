namespace ImmoCalc.Domain
{
	/// <summary>
	/// Loyer
	/// </summary>
	public class MonthlyRent : ExactAmount<MonthlyRent>
	{
		private MonthlyRent(double value) : base(value)
		{
		}

		public static MonthlyRent From(double value) => new MonthlyRent(value);
	}
}