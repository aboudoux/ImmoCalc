namespace ImmoCalc.Domain
{
	/// <summary>
	/// Gain mensuel
	/// </summary>
	public class MonthlyGain : RoundedAmount<MonthlyGain>
	{
		public MonthlyGain(double value) : base(value)
		{
		}

		public static MonthlyGain Of(MonthlyPayment monthlyPayment, MonthlyIncome monthlyIncome)
			=> new MonthlyGain(monthlyIncome.Value - monthlyPayment.Value);
	}
}