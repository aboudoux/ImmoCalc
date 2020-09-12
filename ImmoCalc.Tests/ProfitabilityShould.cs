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
		[InlineData(1500, 600, 4.4651)]
		public void BeCalculated(double buyingPrice, double monthlyRent, double expectedValue)
		{
			Profitability.Of(BuyingPrice.From(buyingPrice), Make<MonthlyIncome>.With(monthlyRent)).Value
				.Should().Be(expectedValue);
		}
	}
}