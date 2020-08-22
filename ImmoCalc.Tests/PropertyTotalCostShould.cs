using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class PropertyTotalCostShould
	{
		[Theory]
		[InlineData(100000, 10000, true, 117500)]
		[InlineData(100000, 10000, false, 117500)]
		public void BeComputedFromData(double buyingPrice, double renovationPrice, bool includeRenovation, double expectedCost) 
		{
			var price = BuyingPrice.From(buyingPrice);
			var propertyTotalCost = PropertyTotalCost.Of(price,
				Renovation.From(renovationPrice).IncludedInLoanAmount(includeRenovation));

			propertyTotalCost.Value.Should().Be(expectedCost);
		}
	}
}