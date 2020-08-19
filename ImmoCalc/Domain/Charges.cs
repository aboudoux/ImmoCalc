namespace ImmoCalc.Domain
{
	public class Charges : ExactAmount<Charges>
	{
		private Charges(double value) : base(value)
		{
		}

		public static Charges From(double value) => new Charges(value);
	}
}