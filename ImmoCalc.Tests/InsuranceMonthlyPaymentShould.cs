using FluentAssertions;
using ImmoCalc.Domain;
using Xunit;

namespace ImmoCalc.Tests
{
	public class InsuranceMonthlyPaymentShould
	{
		[Theory]
		[InlineData(65000,1,54)]
		[InlineData(100000,1.25,104)]
		public void BeCalculated(double buyingPrice, double insuranceRate, double expected)
		{
			InsuranceMonthlyPayment.Of(BuyingPrice.From(buyingPrice), InsuranceRate.From(insuranceRate)).Value
				.Should().Be(expected);
		}
	}
}