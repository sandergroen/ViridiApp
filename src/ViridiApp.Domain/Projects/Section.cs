namespace ViridiApp.Domain.Projects
{
    public class Section
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Board Board { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }

        public Section()
        {
            Issues = new HashSet<Issue>();
        }
    }
}
