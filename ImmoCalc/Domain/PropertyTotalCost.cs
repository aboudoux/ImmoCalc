namespace ImmoCalc.Domain
{
	/// <summary>
	/// Cout total du bien
	/// </summary>
	public class PropertyTotalCost : RoundedValue<PropertyTotalCost>
	{
		private PropertyTotalCost(double value) : base(value)
		{
		}

		public static PropertyTotalCost Of(BuyingPrice buyingPrice, Renovation renovation)
			=> new PropertyTotalCost(buyingPrice.Value + NotaryFees.Of(buyingPrice).Value + renovation.Value);
	}
}