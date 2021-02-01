using System.Collections.Generic;
using ImmoCalc.Domain;

namespace ImmoCalc.Tests.Assets
{
	public class ProjectIdMapping
	{
		private readonly Dictionary<string, ProjectId> _mapping = new Dictionary<string, ProjectId>();

		public void Add(string testId, ProjectId projectId) => _mapping.Add(testId, projectId);

		public ProjectId Get(string testId) => _mapping[testId];
	}
}