using System;

namespace ImmoCalc.Domain
{
	public abstract class RoundedAmount : ExactAmount
	{
		protected RoundedAmount(double value) : base(Math.Round(value, MidpointRounding.ToEven)) {
		}
	}
}