﻿using System;
using BlazorState;
using ImmoCalc.Domain;
using ImmoCalc.Infrastructures;

namespace ImmoCalc.Stores.ProjectList
{
	public class ProjectListState : State<ProjectListState>
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
			public bool FromStartup { get; }

			public LoadProjectList(bool fromStartup = false)
			{
				FromStartup = fromStartup;
			}
		}

		public class LoadingProjectList : IAction
		{
		}

		public class RemoveProject : IAction
		{
			public ProjectId Id { get; }

			public RemoveProject(ProjectId id)
			{
				Id = id;
			}
		}
	}
}