namespace ViridiApp.Domain.Projects
{
    public class Board {
        public int Id { get; set; }
        public virtual ICollection<Section> Sections { get; set; }

        public Board()
        {
            Sections = new HashSet<Section>();
        }
    }
}