namespace ImmoCalc.Domain
{
	public interface IValueObject
	{
	}

	public interface IValue<out T> : IValueObject {
		T Value { get; }
	}
}