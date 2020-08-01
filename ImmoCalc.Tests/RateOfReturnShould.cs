using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class RateOfReturnShould
	{
		[Theory]
		[InlineData(139000, 800, 0.0642)]
		public void BeCalculated(double buyingPrice, double monthlyRent, double expectedValue)
		{
			RateOfReturn.Of(BuyingPrice.From(buyingPrice), MonthlyRent.From(monthlyRent)).Value
				.Should().Be(expectedValue);
		}
	}
}