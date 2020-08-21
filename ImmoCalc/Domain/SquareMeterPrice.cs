namespace ImmoCalc.Domain
{
	/// <summary>
	/// Prix au m�tre carr�
	/// </summary>
	public class SquareMeterPrice : ExactAmount<SquareMeterPrice>
	{
		private SquareMeterPrice(double value) : base(value)
		{
		}

		public static SquareMeterPrice Of(BuyingPrice price, Surface surface) 
			=> new SquareMeterPrice(price.Value / surface.Value);
	}
}