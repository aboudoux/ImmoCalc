using System;

namespace ImmoCalc.Domain
{
	public class ProjectId : IValue<Guid>
	{
		public Guid Value { get; }

		public ProjectId(Guid id) => Value = id;

		public static ProjectId From(Guid value) => new ProjectId(value);

		public static ProjectId Empty => new ProjectId(Guid.Empty);

		public static ProjectId New => new ProjectId(Guid.NewGuid());
	}
}