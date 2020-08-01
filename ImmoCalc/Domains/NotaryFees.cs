using ImmoCalc.Domains;

namespace ImmoCalc.Tests
{
	public class NotaryFees : Amount
	{
		private NotaryFees(double value) : base(value)
		{
		}
		
		public static NotaryFees Of(BuyingPrice price) 
			=> new NotaryFees(7.5d * price.Value / 100);
	}
}