namespace ImmoCalc.Domain
{
	public class NotaryFees : ExactAmount
	{
		private NotaryFees(double value) : base(value)
		{
		}

		public static NotaryFees Empty => new NotaryFees(0);
		
		public static NotaryFees Of(BuyingPrice price) 
			=> new NotaryFees(7.5d * price.Value / 100);
	}
}