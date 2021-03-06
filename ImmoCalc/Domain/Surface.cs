namespace ImmoCalc.Domain
{
	/// <summary>
	/// Surface en m2
	/// </summary>
	public class Surface : ExactValue<Surface>
	{
		private Surface(double value) : base(value)
		{
		}

		public static Surface From(double surface) => new Surface(surface);
	}
}