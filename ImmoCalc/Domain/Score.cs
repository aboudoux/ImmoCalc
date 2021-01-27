using System;

namespace ImmoCalc.Domain
{
	/// <summary>
	/// La note attribuée au bien (une note sur 10 qui peut être superieure ou négative)
	/// </summary>
	public class Score : ExactValue<Score>
	{
		private const double ChargesCoefficient = 1;
		private const double ProfitabilityCoefficient = 2;
		private const double MonthlyGainCoefficient = 3;
		private static double TotalCoefficient => ChargesCoefficient + ProfitabilityCoefficient + MonthlyGainCoefficient;

		private Score(double value) : base(value)
		{
		}

		public static Score Of(Profitability profitability, MonthlyGain monthlyGain, Charges charges, PropertyTax propertyTax)
			=> new Score(((ProfitabilityScore.From(profitability).Value * ProfitabilityCoefficient) +
						 (MonthlyGainScore.From(monthlyGain).Value * MonthlyGainCoefficient) +
			             (ChargesScore.From(charges, propertyTax).Value * ChargesCoefficient)) / TotalCoefficient);

		private class ProfitabilityScore : ExactValue<ProfitabilityScore>
		{
			private ProfitabilityScore(double value) : base(value)
			{
			}

			public static ProfitabilityScore From(Profitability profitability) => new ProfitabilityScore((profitability.Value * 100) - 2);
		}

		private class MonthlyGainScore : ExactValue<MonthlyGainScore>
		{
			private MonthlyGainScore(double value) : base(value)
			{
			}

			public static MonthlyGainScore From(MonthlyGain monthlyGain)
			{
				return monthlyGain.Value <= 0 
					? new MonthlyGainScore(5 - (Math.Abs(monthlyGain.Value) / 40)) 
					: new MonthlyGainScore(5 + (monthlyGain.Value / 40));
			}
		}

		private class ChargesScore : ExactValue<ChargesScore>
		{
			private ChargesScore(double value) : base(value)
			{
			}

			public static ChargesScore From(Charges charges, PropertyTax propertyTax)
				=> new ChargesScore(10 - ((charges.Value + (propertyTax.Value / 12)) / 30));
		}
	}
}