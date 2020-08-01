using System;

namespace ImmoCalc.Domains
{
	public class MonthlyPayment : Amount
	{
		protected MonthlyPayment(double value) : base(Math.Round(value, MidpointRounding.ToEven))
		{
		}

		public static MonthlyPayment From(BuyingPrice price, LoanDuration duration, LoanRate rate) 
			=> new MonthlyPayment( (price.Value * (rate.Value/12)) / (1 - Math.Pow((1+(rate.Value/12)), -12 * duration.Value)));
	}
}