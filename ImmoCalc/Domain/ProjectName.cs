namespace ImmoCalc.Domain
{
	public class ProjectName : IValue<string>
	{
		public string Value { get; }

		private ProjectName(string value)
		{
			Value = value;
		}

		public static ProjectName From(string value) => new ProjectName(value);

		public static ProjectName Empty => new ProjectName(string.Empty);
	}
}