using System;

namespace ImmoCalc.Domain
{
	/// <summary>
	/// Mensualit� du pr�t
	/// </summary>
	public class MonthlyPayment : RoundedValue<MonthlyPayment>
	{
		private MonthlyPayment(double value) : base(value)
		{
		}

		public static MonthlyPayment Of(LoanAmount loanAmount, LoanDuration duration, LoanRate rate) 
			=> new MonthlyPayment( (loanAmount.Value * (rate.Value/12)) / (1 - Math.Pow((1+(rate.Value/12)), -12 * duration.Value)));
	}
}