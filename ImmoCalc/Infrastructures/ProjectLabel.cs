using System;

namespace ImmoCalc.Infrastructures
{
	public class ProjectLabel
	{
		public ProjectLabel(Guid id, string label, string address)
		{
			Id = id;
			Label = label;
			Address = address;
		}

		public string Label { get; }
		public string Address { get; }
		public Guid Id { get; }
	}
}