using ViridiApp.Domain;
using ViridiApp.Domain.Projects;
using ViridiApp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ViridiApp.Data.Repositories
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {

        public BoardRepository(ViridiContext context) : base(context)
        {}
        public async Task<Board> GetBoardWithSectionsAndIssues(int id)
        {
            return await ViridiContext.Boards
                .Include(b => b.Sections.Select(s => s.Issues))
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public ViridiContext ViridiContext
       {
           get { return Context as ViridiContext; }
       }
    }
}