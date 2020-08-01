namespace ImmoCalc.Domain
{
	public class InsuranceMonthlyPayment :RoundedAmount
	{
		private InsuranceMonthlyPayment(double value) : base(value)
		{
		}

		public static InsuranceMonthlyPayment Of(BuyingPrice price, InsuranceRate rate) 
			=> new InsuranceMonthlyPayment((price.Value * rate.Value) / 12);
	}
}