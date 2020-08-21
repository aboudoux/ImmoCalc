using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class PropertyTotalCostShould
	{
		[Theory]
		[InlineData(100000, true, 10000, true, 117500)]
		[InlineData(100000, false, 10000, true, 117500)]
		[InlineData(100000, true, 10000, false, 117500)]
		[InlineData(100000, false, 10000, false, 117500)]
		public void BeComputedFromData(double buyingPrice, bool includeNotaryFees, double renovationPrice, bool includeRenovation, double expectedCost) 
		{
			var price = BuyingPrice.From(buyingPrice);
			var propertyTotalCost = PropertyTotalCost.Of(price,
				NotaryFees.Of(price).IncludedInLoanAmount(includeNotaryFees),
				Renovation.From(renovationPrice).IncludedInLoadAmount(includeRenovation));

			propertyTotalCost.Value.Should().Be(expectedCost);
		}
	}
}