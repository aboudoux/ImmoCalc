using System.IO;

namespace ImmoCalc.Domain
{
	public abstract class Ratio
	{
		protected Ratio(double value) 
		{
			if (value < 0 || value > 100)
				throw new InvalidDataException("Le taux doit être compris entre 0 et 100%");
			Value = value / 100;
		}
		public double Value { get; }
	}
}