namespace ImmoCalc.Domain
{
	public class TotalMonthlyPayment : RoundedValue<TotalMonthlyPayment>
	{
		private TotalMonthlyPayment(double value) : base(value)
		{
		}

		public static TotalMonthlyPayment Of(MonthlyPayment monthlyPayment, InsuranceMonthlyPayment insuranceMonthlyPayment)
			=> new TotalMonthlyPayment(monthlyPayment.Value + insuranceMonthlyPayment.Value);
	}
}