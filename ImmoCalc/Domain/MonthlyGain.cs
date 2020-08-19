namespace ImmoCalc.Domain
{
	public class MonthlyGain : RoundedAmount<MonthlyGain>
	{
		public MonthlyGain(double value) : base(value)
		{
		}

		public static MonthlyGain Of(MonthlyPayment monthlyPayment, MonthlyRent monthlyRent)
			=> new MonthlyGain(monthlyRent.Value - monthlyPayment.Value);
	}
}