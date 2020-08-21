using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class SquareMeterPriceShould
	{
		[Theory]
		[InlineData(150000,25, 6000)]
		public void CalculatePrice(double totalPrice, double squareMeter, double expectedPrice)
		{
			SquareMeterPrice.Of(BuyingPrice.From(totalPrice), Surface.From(squareMeter)).Value.Should().Be(expectedPrice);
		}
	}
}