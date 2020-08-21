namespace ImmoCalc.Domain
{
	/// <summary>
	/// Pris d'achat
	/// </summary>
	public class BuyingPrice : ExactAmount<BuyingPrice>
	{
		protected BuyingPrice(double value) : base(value)
		{
		}

		public static BuyingPrice From(double value) => new BuyingPrice(value);
	}
}