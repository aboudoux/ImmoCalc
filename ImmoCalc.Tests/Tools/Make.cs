using System;
using System.Reflection;

namespace ImmoCalc.Tests.Tools
{
	public class Make<T> where T : class
	{
		public static T With(double value) => Construct<T>(new[] {typeof(double)}, new[] {(object)value});

		private static TU Construct<TU>(Type[] paramTypes, object[] paramValues) 
		{
			var t = typeof(T);

			var ci = t.GetConstructor(
				BindingFlags.Instance | BindingFlags.NonPublic,
				null, paramTypes, null);

			if(ci == null)
				throw new Exception("Impossible de trouver un constructeur compatible pour le type " + typeof(TU).Name);

			return (TU) ci.Invoke(paramValues);
		}

	}
}