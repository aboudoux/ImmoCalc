namespace ImmoCalc.Domain
{
	public class LoanRate : Ratio
	{
		private LoanRate(double value) : base(value)
		{
		}
		public static LoanRate From(double rate)
			=> new LoanRate(rate);
	}
}