using ImmoCalc.Domain;

namespace ImmoCalc.Tests.Tools
{
	public class TestNotaryFees : NotaryFees
	{
		protected TestNotaryFees(double value) : base(value)
		{
		}

		public static TestNotaryFees From(double value) => new TestNotaryFees(value);
	}
}