namespace ImmoCalc.Domain
{
	/// <summary>
	/// Montant de l'emprunt
	/// </summary>
	public class LoanAmount : RoundedAmount<LoanAmount>
	{
		private LoanAmount(double value) : base(value)
		{
		}

		public static LoanAmount Of(BuyingPrice buyingPrice, NotaryFees notaryFees, Renovation renovation)
			=> new LoanAmount(buyingPrice.Value + 
			                  (notaryFees.IsIncludedInLoadAmount ? notaryFees.Value : 0) + 
			                  (renovation.IsIncludedInLoadAmount ? renovation.Value : 0));
	}
}