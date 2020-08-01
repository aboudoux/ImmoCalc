using FluentAssertions;
using ImmoCalc.Shared;
using Xunit;

namespace ImmoCalc.Tests
{
	public class DisplayDecimalShould
	{
		[Theory]
		[InlineData(null, "")]
		[InlineData("", "")]
		[InlineData(" ", "")]
		[InlineData("10", "10")]
		[InlineData("100", "100")]
		[InlineData("1000", "1 000")]
		[InlineData("1000000", "1 000 000")]
		[InlineData("2532", "2 532")]
		[InlineData("1500,", "1 500,")]
		[InlineData("1500,1", "1 500,1")]
		[InlineData("1500,12", "1 500,12")]
		[InlineData("235154574,2415454", "235 154 574,2415454")]
		public void DisplayNumberWithoutCents(string input, string expectedOutput)
		{
			Display.AsDecimal(input).ToString().Should().Be(expectedOutput);
		}

		[Theory]
		[InlineData("10", 10, "10")]
		[InlineData("100", 10, "100")]
		[InlineData("1,", 0, "1")]
		[InlineData("1000,2532", 2, "1 000,25")]
		[InlineData("652154,242432", 1, "652 154,2")]
		public void DisplayNumberWithMaxDecimal(string input, int maxDecimal, string expectedOutput)
		{
			Display.AsDecimal(input).ToString(maxDecimal).Should().Be(expectedOutput);
		}
	}
}