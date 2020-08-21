namespace ImmoCalc.Domain
{
	/// <summary>
	/// Apport
	/// </summary>
	public class Contribution : RoundedAmount<Contribution>
	{
		private Contribution(double value) : base(value)
		{
		}

		public static Contribution Of(NotaryFees notaryFees, Renovation renovation)
			=> new Contribution((notaryFees.IsIncludedInLoadAmount ? 0 : notaryFees.Value) + (renovation.IsIncludedInLoadAmount ? 0 : renovation.Value));
	}
}