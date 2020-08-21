namespace ImmoCalc.Domain
{
	/// <summary>
	/// Taxe fonci�re
	/// </summary>
	public class PropertyTax : ExactAmount<PropertyTax>
	{
		private PropertyTax(double value) : base(value)
		{
		}

		public static PropertyTax From(double value) => new PropertyTax(value);
	}
}