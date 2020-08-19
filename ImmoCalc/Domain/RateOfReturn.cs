using System;

namespace ImmoCalc.Domain
{
	public class RateOfReturn : Ratio<RateOfReturn>
	{
		public RateOfReturn(double value) : base(value) {
		}

		public static RateOfReturn Of(BuyingPrice price, MonthlyRent monthlyRent) 
			=> new RateOfReturn(Math.Round((1200 * monthlyRent.Value) / (price.Value + NotaryFees.Of(price).Value),2) );
	}
}