using System.Collections.Generic;
using System.Threading.Tasks;
using ViridiApp.Domain.Projects;
using ViridiApp.Domain.Repositories;
using ViridiApp.Application.Interfaces;

namespace ViridiApp.Application.Services {
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository ?? throw new ArgumentNullException(nameof(issueRepository));
        }

        public async Task<Issue> GetIssue(int id)
        {
            return await _issueRepository.GetByIdAsync(id);
        }
        public async Task UpdateIssue(Issue issue)
        {
            await _issueRepository.UpdateAsync(issue);
        }
    }
}