using System;
using BlazorState;
using ImmoCalc.Infrastructures;

namespace ImmoCalc.Stores.Projects
{
	public class ProjectsState : State<ProjectsState>
	{
		public ProjectLabel[] ProjectList { get; set; }
		public bool ProjectListLoading { get; set; }

		public override void Initialize()
		{
			ProjectListLoading = false;
			ProjectList = Array.Empty<ProjectLabel>();
		}

		public class LoadProjectList : IAction
		{
		}

		public class LoadingProjectList : IAction
		{
		}

		public class CreateNewProject : IAction
		{
		}

		public class RemoveProject : IAction
		{
		}
	}
}