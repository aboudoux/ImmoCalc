using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Tests.Tools;
using Xunit;

namespace ImmoCalc.Tests
{
	public class ScoreShould
	{
		[Theory]
		[InlineData(6,0,80,600,4.78)]
		[InlineData(3,-200,0,400,1.82)]
		[InlineData(3,-250,0,400,1.19)]
		[InlineData(10,300,110,700,9.65)]
		[InlineData(1,-300,110,700,-0.85)]
		[InlineData(6,-165,80,400,2.81)]
		public void BeComputed(double profitability, double monthlyGain, double charges, double propertyTax, double expectedScore)
		{
			var score = Score.Of(Make<Profitability>.With(profitability),
				Make<MonthlyGain>.With(monthlyGain),
				Charges.From(charges),
				PropertyTax.From(propertyTax)
			);

			score.Value.Should().Be(expectedScore);
		}
	}
}