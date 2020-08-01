namespace ImmoCalc.Domain
{
	public class InsuranceRate : Ratio
	{
		private InsuranceRate(double value) : base(value)
		{
		}
		public static InsuranceRate From(double rate) => new InsuranceRate(rate);
	}
}