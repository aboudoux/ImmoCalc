namespace ImmoCalc.Domains
{
	public class BuyingPrice : Amount
	{
		protected BuyingPrice(double value) : base(value)
		{
		}

		public static BuyingPrice Of(Amount value) => new BuyingPrice(value.Value);
		public new static BuyingPrice Of(double value) => new BuyingPrice(value);
	}
}