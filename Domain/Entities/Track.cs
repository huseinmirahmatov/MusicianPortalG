using Domain.Entity;
using Domain.Enum;

namespace Domain.Entities
{
    public class Track : BaseEntity
    {

        public string Title { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string Duration { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public Rating Rating { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public string Reveiew { get; set; }
        public virtual ICollection<PlayList> PlayLists { get; set; }
    }
}
