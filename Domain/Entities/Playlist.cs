using Domain.Entity;

namespace Domain.Entities
{
    public class PlayList : BaseEntity
    {

        public string Title { get; set; }
        public Track Tracks { get; set; }
        public string TrackId { get; set; }
    }
}
