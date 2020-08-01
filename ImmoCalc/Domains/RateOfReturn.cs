using System;
using System.Text.RegularExpressions;

namespace ImmoCalc.Tests
{
	public class RateOfReturn
	{
		public double Value { get; }

		private RateOfReturn(double value) => Value = value;
		public static RateOfReturn Of(BuyingPrice price, MonthlyRent monthlyRent) 
			=> new RateOfReturn(Math.Round((1200 * monthlyRent.Value) / (price.Value + NotaryFees.Of(price).Value),2) );
	}
}