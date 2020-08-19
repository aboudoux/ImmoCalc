using System;

namespace ImmoCalc.Domain
{
	public abstract class ExactAmount<T> : IAmountValue
		where T : class
	{
		protected ExactAmount(double value)
		{
			Value = value;
		}

		public double Value { get; }

		public T Empty => Activator.CreateInstance(typeof(T), 0) as T;
	}
}