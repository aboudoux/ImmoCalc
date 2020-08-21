namespace ImmoCalc.Domain
{
	/// <summary>
	/// Taux du pr�t
	/// </summary>
	public class LoanRate : Ratio<LoanRate>
	{
		private LoanRate(double value) : base(value)
		{
		}
		public static LoanRate From(double rate) => new LoanRate(rate);
	}
}