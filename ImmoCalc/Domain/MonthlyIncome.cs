namespace ImmoCalc.Domain
{
	/// <summary>
	/// Revenu mensuel
	/// </summary>
	public class MonthlyIncome : RoundedAmount<MonthlyIncome>
	{
		private MonthlyIncome(double value) : base(value)
		{
		}

		public static MonthlyIncome Of(MonthlyRent monthlyRent, Charges charges, PropertyTax propertyTax)
		=> new MonthlyIncome(monthlyRent.Value - (charges.IsIncludedInMonthlyRent ? charges.Value : 0) - (propertyTax.Value / 12));
	}
}