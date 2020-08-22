using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class MonthlyPaymentShould
	{
		[Theory]
		[InlineData(300000,20,1.2,1407)]
		[InlineData(139000,15,1.3,850)]
		[InlineData(65000,15,1.3,398)]
		[InlineData(65000,20,1.3,308)]
		public void BeCalculated(double buyingPrice, int duration, double loanRate, double monthlyPaymentExpected)
		{
			MonthlyPayment.Of(Make<LoanAmount>.With(buyingPrice), LoanDuration.From(duration), LoanRate.From(loanRate))
				.Value.Should().Be(monthlyPaymentExpected);
		}
	}
}