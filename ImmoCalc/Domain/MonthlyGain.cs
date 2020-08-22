namespace ImmoCalc.Domain
{
	/// <summary>
	/// Gain mensuel
	/// </summary>
	public class MonthlyGain : RoundedValue<MonthlyGain>
	{
		private MonthlyGain(double value) : base(value)
		{
		}

		public static MonthlyGain Of(TotalMonthlyPayment monthlyPayment, MonthlyIncome monthlyIncome)
			=> new MonthlyGain(monthlyIncome.Value - monthlyPayment.Value);
	}
}