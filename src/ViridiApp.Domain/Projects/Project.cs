namespace ViridiApp.Domain.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }

        public Project()
        {
            Issues = new HashSet<Issue>();
        }
    }
}
