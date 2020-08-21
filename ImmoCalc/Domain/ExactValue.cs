using System;

namespace ImmoCalc.Domain
{
	public abstract class ExactValue<T> : IValue
		where T : class
	{
		protected ExactValue(double value)
		{
			Value = Math.Round(value, 2);
		}

		public double Value { get; }

		public T Empty => Activator.CreateInstance(typeof(T), 0) as T;

		public bool IsEmpty() => Math.Abs(Value) < double.Epsilon;
	}
}