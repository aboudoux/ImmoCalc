namespace ImmoCalc.Domain
{
	/// <summary>
	/// Loyer
	/// </summary>
	public class MonthlyRent : ExactValue<MonthlyRent>
	{
		private MonthlyRent(double value) : base(value)
		{
		}

		public static MonthlyRent From(double value) => new MonthlyRent(value);
	}
}