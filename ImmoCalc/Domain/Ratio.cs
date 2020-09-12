using System.IO;

namespace ImmoCalc.Domain
{
	public abstract class Ratio<T> : EmptyValue<T>
		where T : class
	{
		protected Ratio(double value) 
		{
			Value = value / 100;
		}
	}
}