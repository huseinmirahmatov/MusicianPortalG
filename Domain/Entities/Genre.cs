using Domain.Entity;

namespace Domain.Entities
{
    public class Genre : BaseEntity
    {

        public string Title { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

    }
}
