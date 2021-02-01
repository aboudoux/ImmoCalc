using System;
using BlazorState;
using ImmoCalc.Domain;

namespace ImmoCalc.Stores.CurrentProject {
	public class CurrentProjectState : State<CurrentProjectState>
	{
		public Project Project { get; set; }

		public override void Initialize()
		{
			Project = new Project(ProjectId.New);
		}

		
		public class ChangeValue : IAction
		{
			public IValueObject Value { get; }
			public ChangeValue(IValueObject value) => Value = value;
		}

		public abstract class IncludeAction : IAction {
			public bool Include { get; }
			protected IncludeAction(bool include) => Include = include;
		}

		public class IncludeChargesInMonthlyRent : IncludeAction {
			public IncludeChargesInMonthlyRent(bool include) : base(include) { }
		}

		public class IncludeRenovationInLoadAmount : IncludeAction {
			public IncludeRenovationInLoadAmount(bool include) : base(include) { }
		}

		public class IncludeNotaryFeesInLoadAmount : IncludeAction {
			public IncludeNotaryFeesInLoadAmount(bool include) : base(include) { }
		}

		public class Load : IAction
		{
			public ProjectId ProjectId { get; }
			public Load(ProjectId projectId)
			{
				ProjectId = projectId;
			}
		}

		public class Save : IAction
		{
			public Project Project { get; }

			public Save(Project project)
			{
				Project = project;
			}
		}

		public class CreateNewProject : IAction {
		}
	}
}
