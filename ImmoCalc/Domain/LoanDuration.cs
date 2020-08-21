using System.IO;

namespace ImmoCalc.Domain
{
	/// <summary>
	/// Durée du prêt
	/// </summary>
	public class LoanDuration
	{
		public int Value { get; }

		private LoanDuration(int duration)
		{
			if(duration > 30)
				throw new InvalidDataException("La durée du prêt ne peut être supérieure à 30 ans");
			Value = duration;
		}

		public static LoanDuration From(int duration) => new LoanDuration(duration);
	}
}