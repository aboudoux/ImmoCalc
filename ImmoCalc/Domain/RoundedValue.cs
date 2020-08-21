using System;

namespace ImmoCalc.Domain
{
	public abstract class RoundedValue<T> : ExactValue<T> where T : class
	{
		protected RoundedValue(double value) : base(Math.Round(value, MidpointRounding.ToEven)) {
		}
	}
}