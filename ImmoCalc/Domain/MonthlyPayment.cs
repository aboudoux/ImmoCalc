using System;

namespace ImmoCalc.Domain
{
	public class MonthlyPayment : RoundedAmount
	{
		protected MonthlyPayment(double value) : base(value)
		{
		}

		public static MonthlyPayment From(BuyingPrice price, LoanDuration duration, LoanRate rate) 
			=> new MonthlyPayment( (price.Value * (rate.Value/12)) / (1 - Math.Pow((1+(rate.Value/12)), -12 * duration.Value)));
	}
}