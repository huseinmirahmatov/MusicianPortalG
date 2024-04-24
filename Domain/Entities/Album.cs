using Domain.Entity;

namespace Domain.Entities
{
    public class Album : BaseEntity
    {

        public string Title { get; set; }
        public Artist Artist { get; set; }

        public int ArtistId { get; set; }
        public string ReleaseYear { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
