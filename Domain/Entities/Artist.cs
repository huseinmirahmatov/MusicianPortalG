using Domain.Entity;

namespace Domain.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; }

        public string PopularTrack { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
