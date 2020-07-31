using FluentAssertions;
using ImmoCalc.Domains;
using Xunit;

namespace ImmoCalc.Tests {
	public class StringExtensionShould 
	{
		[Theory]
		[InlineData("10","10")]
		[InlineData("100","100")]
		[InlineData("1000", "1 000")]
		[InlineData("1000000", "1 000 000")]
		[InlineData("1500,10", "1 500")]
		[InlineData("235154574,2415454", "235 154 574")]
		public void FormatDecimalWithoutCentsNumberCorrectly(string input, string expectedOutput)
		{
			input.FormatDecimal().Should().Be(expectedOutput);
		}

		[Theory]
		[InlineData("10", "10,00")]
		[InlineData("100", "100,00")]
		[InlineData("1000", "1 000,00")]
		[InlineData("1000000", "1 000 000,00")]
		[InlineData("1500,10", "1 500,10")]
		[InlineData("235154574,2415454", "235 154 574,24")]
		public void FormatDecimalWithCentsNumberCorrectly(string input, string expectedOutput) {
			input.FormatDecimal(true).Should().Be(expectedOutput);
		}

		[Theory]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("1")]
		[InlineData("1,1")]
		public void SayOkForValidDecimal(string input)
		{
			input.IsValidDecimal().Should().BeTrue();
		}
	}
}
