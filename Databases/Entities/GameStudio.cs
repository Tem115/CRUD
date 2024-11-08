

namespace Databases.Entities
{
    public class GameStudio : BaseEntity<Guid>
    {
        public Guid GameId { get; set; }

        public Guid StudioId { get; set; }
    }
}
