using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmoCalc.Domain.Extensions {
	public static class TimeExtensions
	{
		public static TimeSpan Seconds(this int source) => TimeSpan.FromSeconds(source);
	}
}
