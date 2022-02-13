using ViridiApp.Domain.Projects;
using System.Collections.Generic;

namespace ViridiApp.Domain.Repositories {
    public interface IBoardRepository : IRepository<Board>
    {
        Task<Board> GetBoardWithSectionsAndIssues(int id);
    }
}