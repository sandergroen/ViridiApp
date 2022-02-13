namespace ViridiApp.Domain.Projects {
    public class Issue {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public uint Weight { get; set; }
        public Project Project { get; set; }
        public Milestone? Milestone { get; set; }
        public Epic? Epic { get; set; }
    }
}