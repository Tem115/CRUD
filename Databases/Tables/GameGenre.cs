

namespace Databases.Tables
{
    public class GameGenre : TableBase<Guid>
    {
        public Guid GameId { get; set; }

        public Guid GenreId { get; set; }
    }
}