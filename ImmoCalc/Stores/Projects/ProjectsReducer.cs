using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Infrastructures;
using MediatR;

namespace ImmoCalc.Stores.Projects {
	public class ProjectsReducer : ActionHandler<ProjectsState.LoadProjectList>,
		IRequestHandler<ProjectsState.LoadingProjectList>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMediator _mediator;
		private ProjectsState State => Store.GetState<ProjectsState>();
		public ProjectsReducer(IStore store, IProjectRepository projectRepository, IMediator mediator) : base(store)
		{
			_projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		public override async Task<Unit> Handle(ProjectsState.LoadProjectList action, CancellationToken cancellationToken)
		{
			await _mediator.Send(new ProjectsState.LoadingProjectList(), cancellationToken);
			var projectsList = await _projectRepository.GetAllProjects();
			State.ProjectListLoading = false;
			State.ProjectList = projectsList;
			return Unit.Value;
		}

		public Task<Unit> Handle(ProjectsState.LoadingProjectList request, CancellationToken cancellationToken)
		{
			State.ProjectListLoading = true;
			return Unit.Task;
		}
	}
}
