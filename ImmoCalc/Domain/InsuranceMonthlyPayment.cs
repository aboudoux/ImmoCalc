namespace ImmoCalc.Domain
{
	/// <summary>
	/// Mensualité de l'assurance
	/// </summary>
	public class InsuranceMonthlyPayment : RoundedAmount<InsuranceMonthlyPayment>
	{
		private InsuranceMonthlyPayment(double value) : base(value)
		{
		}

		public static InsuranceMonthlyPayment Of(BuyingPrice price, InsuranceRate rate) 
			=> new InsuranceMonthlyPayment((price.Value * rate.Value) / 12);
	}
}