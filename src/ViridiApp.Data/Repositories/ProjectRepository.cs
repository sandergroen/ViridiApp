using ViridiApp.Domain;
using ViridiApp.Domain.Projects;
using ViridiApp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ViridiApp.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ViridiContext context)
            : base(context)
        {
        }

        public async Task<Project> GetProjectWithIssues(int id)
        {
            return await ViridiContext.Projects.Include(i => i.Issues)
                 .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Issue> AddIssues(Issue issue)
        {
            Context.Set<Issue>().Add(issue);
            await Context.SaveChangesAsync();
            return issue;
        }

        public ViridiContext ViridiContext
        {
            get { return Context as ViridiContext; }
        }
    }
}