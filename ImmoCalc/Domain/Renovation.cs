namespace ImmoCalc.Domain
{
	/// <summary>
	/// Travaux
	/// </summary>
	public class Renovation : RoundedValue<Renovation>
	{
		private Renovation(double value) : base(value)
		{
		}

		public static Renovation From(double value) => new Renovation(value);


		public bool IsIncludedInLoadAmount { get; private set; }
		public Renovation IncludedInLoadAmount(bool included)
		{
			IsIncludedInLoadAmount = included;
			return this;
		}
	}
}