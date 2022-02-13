using ViridiApp.Domain.Projects;
using ViridiApp.Domain.Repositories;

namespace ViridiApp.Data.Repositories
{
    public class IssueRepository : Repository<Issue>, IIssueRepository
    {
        public IssueRepository(ViridiContext context)
            : base(context)
        {
        }

        public ViridiContext ViridiContext
        {
            get { return Context as ViridiContext; }
        }
    }
}