using Microsoft.EntityFrameworkCore;
using ViridiApp.Domain;
using ViridiApp.Domain.Projects;

namespace ViridiApp.Data
{
    public class ViridiContext : DbContext
    {
        public ViridiContext(DbContextOptions<ViridiContext> options)
            : base(options) {
                // Projects = Set<Project>();
                // Issues = Set<Issue>();
                // Sections = Set<Section>();
                // Epics = Set<Epic>();
                // Milestones = Set<Milestone>();
                // Iterations = Set<Iterations>();
             }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Iteration> Iterations { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}