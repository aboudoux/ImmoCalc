using FluentAssertions;
using ImmoCalc.Domains;
using Xunit;

namespace ImmoCalc.Tests
{
	public class NotaryFeesShould
	{
		[Theory]
		[InlineData(150000,11250)]
		public void BeCalculatedFromAmount(double amount, double expected)
		{
			NotaryFees.Of(BuyingPrice.Of(amount)).Value.Should().Be(expected);
		}
	}
}