using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using ImmoCalc.Infrastructures;
using ImmoCalc.Stores.CurrentProject;
using MediatR;

namespace ImmoCalc.Stores.ProjectList {
	public class ProjectListReducer : ActionHandler<ProjectListState.LoadProjectList>,
		IRequestHandler<ProjectListState.LoadingProjectList>,
		IRequestHandler<CurrentProjectState.Save>,
		IRequestHandler<ProjectListState.RemoveProject>
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

		public async Task<Unit> Handle(CurrentProjectState.Save request, CancellationToken cancellationToken)
		{
			await _projectRepository.SaveProject(request.Project);
			return Unit.Value;
		}

		public async Task<Unit> Handle(ProjectListState.RemoveProject request, CancellationToken cancellationToken)
		{
			await _projectRepository.Remove(request.Id);
			var remove = State.ProjectList.FirstOrDefault(a => a.Id == request.Id.Value);
			if (remove != null)
				State.ProjectList = State.ProjectList.Except(new []{ remove }).ToArray();
			return Unit.Value;
		}
	}
}
