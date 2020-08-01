using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class NotaryFeesShould
	{
		[Theory]
		[InlineData(150000,11250)]
		public void BeCalculatedFromAmount(double amount, double expected)
		{
			NotaryFees.Of(BuyingPrice.From(amount)).Value.Should().Be(expected);
		}
	}
}