namespace ImmoCalc.Domain
{
	public class InsuranceRate : Ratio<InsuranceRate>
	{
		private InsuranceRate(double value) : base(value)
		{
		}
		public static InsuranceRate From(double rate) => new InsuranceRate(rate);
	}
}