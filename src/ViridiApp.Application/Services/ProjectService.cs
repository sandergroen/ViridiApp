using System.Collections.Generic;
using System.Threading.Tasks;
using ViridiApp.Domain.Projects;
using ViridiApp.Domain.Repositories;
using ViridiApp.Application.Interfaces;

namespace ViridiApp.Application.Services {
    public class ProjectService : IProjectService
    {

        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task<IEnumerable<Project>> GetProjectList()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> GetProject(int id)
        {
            return await _projectRepository.GetProjectWithIssues(id);
        }

        public async Task<Project> AddProject(Project project) 
        {
            return await _projectRepository.AddAsync(project);
        }

        public async Task UpdateProject(Project project)
        {
            await _projectRepository.UpdateAsync(project);
        }
    }
}