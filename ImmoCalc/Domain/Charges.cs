namespace ImmoCalc.Domain
{
	/// <summary>
	/// Charges
	/// </summary>
	public class Charges : ExactAmount<Charges>
	{
		private Charges(double value) : base(value)
		{
		}

		public static Charges From(double value) => new Charges(value);

		public bool IsIncludedInMonthlyRent { get; private set; }
		public Charges IncludedInMonthlyRent(bool included)
		{
			IsIncludedInMonthlyRent = included;
			return this;
		}
	}
}