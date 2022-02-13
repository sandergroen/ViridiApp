using System.Collections.Generic;
using System.Threading.Tasks;
using ViridiApp.Domain.Projects;

namespace ViridiApp.Application.Interfaces
{
    public interface IIssueService
    {
        Task<Issue> GetIssue(int id);
        Task UpdateIssue(Issue issue);
    }
}
