namespace ImmoCalc.Domain
{
	public abstract class ExactAmount
	{
		protected ExactAmount(double value)
		{
			Value = value;
		}

		public double Value { get; }
	}
}