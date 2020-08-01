using System;

namespace ImmoCalc.Domain
{
	public abstract class ExactAmount
	{
		protected ExactAmount(double value)
		{
			Value = value;
		}

		public double Value { get; }
	}

	public abstract class RoundedAmount : ExactAmount
	{
		protected RoundedAmount(double value) : base(Math.Round(value, MidpointRounding.ToEven)) {
		}
	}
}