

namespace Databases.Entities
{
    public class GameGenre : BaseEntity<Guid>
    {
        public Guid GameId { get; set; }

        public Guid GenreId { get; set; }
    }
}