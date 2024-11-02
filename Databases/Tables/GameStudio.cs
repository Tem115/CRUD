

namespace Databases.Tables
{
    public class GameStudio : TableBase<Guid>
    {
        public Guid GameId { get; set; }

        public Guid StudioId { get; set; }
    }
}
