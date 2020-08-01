using ImmoCalc.Domains;

namespace ImmoCalc.Tests
{
	public class SquareMeterPrice : Amount
	{
		private SquareMeterPrice(double value) : base(value)
		{
		}

		public static SquareMeterPrice Of(Amount totalPrice, double squareMeter) 
			=> new SquareMeterPrice(totalPrice.Value / squareMeter);
	}
}