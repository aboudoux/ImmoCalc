namespace ImmoCalc.Domain
{
	public class Address : IValue<string>
	{
		public string Value { get; }

		private Address(string value) => Value = value;
		public static Address From(string value) => new Address(value);

		public static Address Empty => new Address(string.Empty);
	}
}