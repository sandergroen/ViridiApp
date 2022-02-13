using System.Collections.Generic;
using System.Threading.Tasks;
using ViridiApp.Domain.Projects;

namespace ViridiApp.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectList();
        Task<Project> GetProject(int id);
        Task<Project> AddProject(Project project);
        Task UpdateProject(Project project);
    }
}
