using System.IO;

namespace ImmoCalc.Domain
{
	/// <summary>
	/// Dur�e du pr�t
	/// </summary>
	public class LoanDuration : EmptyValue<LoanDuration>
	{
		private LoanDuration(int duration)
		{
			if(duration > 30)
				throw new InvalidDataException("La dur�e du pr�t ne peut �tre sup�rieure � 30 ans");
			Value = duration;
		}

		public static LoanDuration From(int duration) => new LoanDuration(duration);
	}
}