namespace ImmoCalc.Domain
{
	/// <summary>
	/// Taxe foncière
	/// </summary>
	public class PropertyTax : ExactAmount<PropertyTax>
	{
		private PropertyTax(double value) : base(value)
		{
		}

		public static PropertyTax From(double value) => new PropertyTax(value);
	}
}