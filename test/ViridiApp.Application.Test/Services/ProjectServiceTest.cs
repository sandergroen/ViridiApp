using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ViridiApp.Domain.Projects;
using ViridiApp.Domain.Repositories;
using ViridiApp.Application.Interfaces;
using ViridiApp.Application.Services;
using System;


namespace ViridiApp.Application.Test {
    [TestClass]
    public class ProjectServiceTest {
        private Mock<IProjectRepository> _mockProjectRepository;
        
        public ProjectServiceTest()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
        }

        [TestMethod]
        public async Task GetProjectList()
        {
            var project1 = new Project{Id=It.IsAny<int>(), Title="Project 1", Description=It.IsAny<string>()};
            var project2 = new Project{Id=It.IsAny<int>(), Title="Project 2", Description=It.IsAny<string>()};

            _mockProjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project1);
            _mockProjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project2);

            var projectService = new ProjectService(_mockProjectRepository.Object);
            var projectList = await projectService.GetProjectList();

            _mockProjectRepository.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [TestMethod]
        public async Task GetProject()
        {
            var project1 = new Project{Id=It.IsAny<int>(), Title="Project 1", Description=It.IsAny<string>()};
            _mockProjectRepository.Setup(x => x.GetProjectWithIssues(It.IsAny<int>())).ReturnsAsync(project1);
            
            var projectService = new ProjectService(_mockProjectRepository.Object);
            var projectList = await projectService.GetProject(It.IsAny<int>());

            _mockProjectRepository.Verify(x => x.GetProjectWithIssues(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public async Task AddProject()
        {
            var project = new Project{Id=It.IsAny<int>(), Title="Project", Description=It.IsAny<string>()};
            _mockProjectRepository.Setup(x => x.AddAsync(project)).ReturnsAsync(project);

            var projectService = new ProjectService(_mockProjectRepository.Object);
            var createdProject = await projectService.AddProject(project);
            
            _mockProjectRepository.Verify(x => x.AddAsync(project), Times.Once);
        }

        [TestMethod]
        public async Task UpdateProject()
        {
            var project = new Project{Id=It.IsAny<int>(), Title="Project", Description=It.IsAny<string>()};
            _mockProjectRepository.Setup(x => x.UpdateAsync(project));

            var projectService = new ProjectService(_mockProjectRepository.Object);
            await projectService.UpdateProject(project);
            _mockProjectRepository.Verify(x => x.UpdateAsync(project), Times.Once);
        }
    }
}