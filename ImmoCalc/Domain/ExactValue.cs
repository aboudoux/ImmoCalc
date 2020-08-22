using System;
using System.Reflection;

namespace ImmoCalc.Domain
{
	public abstract class ExactValue<T> : EmptyValue<T>
		where T : class
	{
		protected ExactValue(double value)
		{
			Value = Math.Round(value, 2);
		}
	}
}