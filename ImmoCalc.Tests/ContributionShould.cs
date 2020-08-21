using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class ContributionShould
	{
		[Theory]
		[InlineData(10000, false, 5000, false, 15000)]
		[InlineData(10000, true, 5000, false, 5000)]
		[InlineData(10000, false, 5000, true, 10000)]
		[InlineData(10000, true, 5000, true, 0)]
		public void BeComputed(double notaryFees, bool includeNotaryFees, double renovation, bool includeRenovation, double expectedContribution)
		{
			var contribution = Contribution.Of(Make<NotaryFees>.With(notaryFees).IncludedInLoanAmount(includeNotaryFees),
				Renovation.From(renovation).IncludedInLoadAmount(includeRenovation));

			contribution.Value.Should().Be(expectedContribution);
		}
	}
}