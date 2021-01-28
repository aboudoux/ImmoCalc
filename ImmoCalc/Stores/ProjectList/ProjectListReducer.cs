using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Infrastructures;
using MediatR;

namespace ImmoCalc.Stores.ProjectList {
	public class ProjectListReducer : ActionHandler<ProjectListState.LoadProjectList>,
		IRequestHandler<ProjectListState.LoadingProjectList>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMediator _mediator;
		private ProjectListState State => Store.GetState<ProjectListState>();
		public ProjectListReducer(IStore store, IProjectRepository projectRepository, IMediator mediator) : base(store)
		{
			_projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		public override async Task<Unit> Handle(ProjectListState.LoadProjectList action, CancellationToken cancellationToken)
		{
			if(action.FromStartup)
				await _mediator.Send(new ProjectListState.LoadingProjectList(), cancellationToken);

			var projectsList = await _projectRepository.GetAllProjects();
			State.ProjectListLoading = false;
			State.ProjectList = projectsList;
			return Unit.Value;
		}

		public Task<Unit> Handle(ProjectListState.LoadingProjectList request, CancellationToken cancellationToken)
		{
			State.ProjectListLoading = true;
			return Unit.Task;
		}
	}
}
