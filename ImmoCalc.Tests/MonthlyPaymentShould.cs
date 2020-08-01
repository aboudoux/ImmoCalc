using System;
using System.IO;
using FluentAssertions;
using ImmoCalc.Domains;
using Xunit;

namespace ImmoCalc.Tests
{
	public class MonthlyPaymentShould
	{
		[Theory]
		[InlineData(300000,20,"1.2","1407")]
		[InlineData(139000,15,"1.3","850")]
		[InlineData(65000,15,"1.3","398")]
		[InlineData(65000,20,"1.3","308")]
		public void BeCalculated(double BuyingPrice, int duration, string loanRate, string monthlyPaymentExpected)
		{
			MonthlyPayment.From(Tests.BuyingPrice.Of(BuyingPrice), LoanDuration.Of(duration), LoanRate.Of(loanRate.ToDouble()))
				.Value.Should().Be(monthlyPaymentExpected.ToDouble());
		}
	}

	public class MonthlyPayment : Amount
	{
		protected MonthlyPayment(double value) : base(Math.Round(value, MidpointRounding.ToEven))
		{
		}

		public static MonthlyPayment From(BuyingPrice price, LoanDuration duration, LoanRate rate)
		{
			return new MonthlyPayment( (price.Value * (rate.Value/12)) / (1 - Math.Pow((1+(rate.Value/12)), -12 * duration.Value)));
		}
	}

	public class LoanDuration
	{
		public int Value { get; }

		private LoanDuration(int duration)
		{
			if(duration > 30)
				throw new InvalidDataException("La durée du prêt ne peut être supérieure à 30 ans");
			Value = duration;
		}

		public static LoanDuration Of(int duration) => new LoanDuration(duration);
	}

	public class LoanRate
	{
		public double Value { get; }
		private LoanRate(double value)
		{
			if (value < 0 || value > 100)
				throw new InvalidDataException("Le taux doit être compris entre 0 et 100%");
			Value = value / 100;
		}

		public static LoanRate Of(double rate) => new LoanRate(rate);
	}

	public static class DoubleExtension
	{
		public static double ToDouble(this string source) => double.Parse(source.Replace(".",","));
	}
}