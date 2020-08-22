using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class LoanAmountShould
	{
		[Theory]
		[InlineData(100000, true, 10000, true, 117500)]
		[InlineData(100000, false, 10000, true, 110000)]
		[InlineData(100000, true, 10000, false, 107500)]
		[InlineData(100000, false, 10000, false, 100000)]
		public void BeComputedFromData(double buyingPrice, bool includeNotaryFees, double renovationPrice, bool includeRenovation, double expectedLoanAmount)
		{
			var price = BuyingPrice.From(buyingPrice);
			var loanAmount = LoanAmount.Of(price, 
				NotaryFees.Of(price).IncludedInLoanAmount(includeNotaryFees),
				Renovation.From(renovationPrice).IncludedInLoanAmount(includeRenovation));

			loanAmount.Value.Should().Be(expectedLoanAmount);
		}
	}
}