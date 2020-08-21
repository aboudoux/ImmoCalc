using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class MonthlyIncomeShould
	{
		[Theory]
		[InlineData(880, 80, true, 600, 750)]
		[InlineData(880, 80, false, 600, 830)]
		public void BeComputedFromData(double monthlyRent, double charges, bool includedCharges, double propertyTax, double expectedIncome)
		{
			var income = MonthlyIncome.Of(MonthlyRent.From(monthlyRent),
				Charges.From(charges).IncludedInMonthlyRent(includedCharges), 
				PropertyTax.From(propertyTax));

			income.Value.Should().Be(expectedIncome);
		}
	}
}