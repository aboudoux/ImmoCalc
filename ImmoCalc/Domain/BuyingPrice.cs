namespace ImmoCalc.Domain
{
	public class BuyingPrice : ExactAmount
	{
		protected BuyingPrice(double value) : base(value)
		{
		}

		public static BuyingPrice From(double value) => new BuyingPrice(value);
	}
}