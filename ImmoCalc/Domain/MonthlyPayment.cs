using System;

namespace ImmoCalc.Domain
{
	/// <summary>
	/// Mensualité du prêt
	/// </summary>
	public class MonthlyPayment : RoundedValue<MonthlyPayment>
	{
		private MonthlyPayment(double value) : base(value)
		{
		}

		public static MonthlyPayment Of(BuyingPrice price, LoanDuration duration, LoanRate rate) 
			=> new MonthlyPayment( (price.Value * (rate.Value/12)) / (1 - Math.Pow((1+(rate.Value/12)), -12 * duration.Value)));
	}
}