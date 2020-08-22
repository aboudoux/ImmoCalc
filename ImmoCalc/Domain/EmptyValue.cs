using System;
using System.Reflection;

namespace ImmoCalc.Domain
{
	public class EmptyValue<T> : IValue
		where T : class
	{
		public static T Empty => Activator.CreateInstance(typeof(T),
			bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic,
			null, new[] {(object) 0}, null) as T;

		public double Value { get; protected set; }

		public bool IsEmpty() => Math.Abs(Value) < double.Epsilon;
		public bool IsDefined() => !IsEmpty();
	}
}