using ImmoCalc.Domain;

namespace ImmoCalc.Tests.Tools
{
	public class TestMonthlyIncome : MonthlyIncome
	{
		protected TestMonthlyIncome(double value) : base(value)
		{
		}

		public static TestMonthlyIncome From(double value) => new TestMonthlyIncome(value);
	}
}