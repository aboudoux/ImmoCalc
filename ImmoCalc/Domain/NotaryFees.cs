namespace ImmoCalc.Domain
{
	/// <summary>
	/// Frais de notaire
	/// </summary>
	public class NotaryFees : ExactAmount<NotaryFees>
	{
		protected NotaryFees(double value) : base(value)
		{
		}

		public static NotaryFees Of(BuyingPrice price) 
			=> new NotaryFees(7.5d * price.Value / 100);

		public bool IsIncludedInLoadAmount {get; private set; }

		public NotaryFees IncludedInLoanAmount(bool include)
		{
			IsIncludedInLoadAmount = include;
			return this;
		} 
	}
}