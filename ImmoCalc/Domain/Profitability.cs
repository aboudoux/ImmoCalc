using System;

namespace ImmoCalc.Domain
{
	/// <summary>
	/// Rentabilité
	/// </summary>
	public class Profitability : Ratio<Profitability>
	{
		private Profitability(double value) : base(value) {
		}

		public static Profitability Of(BuyingPrice price, MonthlyIncome monthlyIncome) 
			=> new Profitability(Math.Round((1200 * monthlyIncome.Value) / (price.Value + NotaryFees.Of(price).Value),2) );
	}
}