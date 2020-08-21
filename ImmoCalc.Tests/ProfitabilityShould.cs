using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class ProfitabilityShould
	{
		[Theory]
		[InlineData(139000, 800, 0.0642)]
		public void BeCalculated(double buyingPrice, double monthlyRent, double expectedValue)
		{
			Profitability.Of(BuyingPrice.From(buyingPrice), TestMonthlyIncome.From(monthlyRent)).Value
				.Should().Be(expectedValue);
		}
	}
}