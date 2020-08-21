using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class MonthlyGainShould
	{
		[Theory]
		[InlineData(500,300,200)]
		[InlineData(605.32,302.25,303)]
		[InlineData(200,300,-100)]
		public void BeComputed(double monthlyIncome, double monthlyPayment, double expected)
		{
			MonthlyGain.Of(TestMonthlyPayment.From(monthlyPayment), TestMonthlyIncome.From(monthlyIncome)).Value
				.Should().Be(expected);
		}
	}
}