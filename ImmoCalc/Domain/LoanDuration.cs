using System.IO;

namespace ImmoCalc.Domain
{
	public class LoanDuration
	{
		public int Value { get; }

		private LoanDuration(int duration)
		{
			if(duration > 30)
				throw new InvalidDataException("La dur�e du pr�t ne peut �tre sup�rieure � 30 ans");
			Value = duration;
		}

		public static LoanDuration Of(int duration) => new LoanDuration(duration);
	}
}