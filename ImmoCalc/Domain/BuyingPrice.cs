namespace ImmoCalc.Domain
{
	public class BuyingPrice : ExactAmount
	{
		protected BuyingPrice(double value) : base(value)
		{
		}

		public static BuyingPrice From(double value) => new BuyingPrice(value);
		public static BuyingPrice From(string value) => new BuyingPrice(double.Parse(value));
		public static BuyingPrice Empty => new BuyingPrice(0);
	}
}