using FluentAssertions;
using Xunit;

namespace ImmoCalc.Tests
{
	public class RateOfReturnShould
	{
		[Theory]
		[InlineData(139000, 800, "6,42")]
		public void BeCalculated(double buyingPrice, double monthlyRent, string expectedValue)
		{
			RateOfReturn.Of(BuyingPrice.Of(buyingPrice), MonthlyRent.Of(monthlyRent)).Value
				.Should().Be(expectedValue.ToDouble());
		}
	}
}