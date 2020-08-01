using FluentAssertions;
using ImmoCalc.Domains;
using Xunit;

namespace ImmoCalc.Tests
{
	public class SquareMeterPriceShould
	{
		[Theory]
		[InlineData(150000,25, 6000)]
		public void CalculatePrice(double totalPrice, double squareMeter, double expectedPrice)
		{
			SquareMeterPrice.Of(Amount.Of(totalPrice), squareMeter).Value.Should().Be(expectedPrice);
		}
	}
}