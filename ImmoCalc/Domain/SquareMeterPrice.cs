namespace ImmoCalc.Domain
{
	public class SquareMeterPrice : ExactAmount
	{
		private SquareMeterPrice(double value) : base(value)
		{
		}

		public static SquareMeterPrice Of(BuyingPrice price, double squareMeter) 
			=> new SquareMeterPrice(price.Value / squareMeter);
	}
}