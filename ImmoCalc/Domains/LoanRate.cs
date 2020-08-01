using System.IO;

namespace ImmoCalc.Domains
{
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
}