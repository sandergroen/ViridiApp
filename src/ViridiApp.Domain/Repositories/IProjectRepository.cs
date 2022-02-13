using ViridiApp.Domain.Projects;
using System.Collections.Generic;

namespace ViridiApp.Domain.Repositories {
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetProjectWithIssues(int id);
        Task<Issue> AddIssues(Issue issue);
    }
}