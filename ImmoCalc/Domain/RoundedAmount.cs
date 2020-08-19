using System;

namespace ImmoCalc.Domain
{
	public abstract class RoundedAmount<T> : ExactAmount<T> where T : class
	{
		protected RoundedAmount(double value) : base(Math.Round(value, MidpointRounding.ToEven)) {
		}
	}
}