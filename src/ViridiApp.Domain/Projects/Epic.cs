namespace ViridiApp.Domain.Projects
{
    public class Epic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }

        public Epic()
        {
            Issues = new HashSet<Issue>();
        }
    }
}