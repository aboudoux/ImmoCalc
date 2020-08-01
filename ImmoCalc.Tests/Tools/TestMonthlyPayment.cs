using ImmoCalc.Domain;

namespace ImmoCalc.Tests.Tools
{
	public class TestMonthlyPayment : MonthlyPayment
	{
		protected TestMonthlyPayment(double value) : base(value)
		{
		}

		public static TestMonthlyPayment From(double value) => new TestMonthlyPayment(value);
	}
}