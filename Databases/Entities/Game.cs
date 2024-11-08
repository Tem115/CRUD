

namespace Databases.Entities
{
    public class Game : BaseEntity<Guid>
    {
        public required string Name { get; set; }

        public List<Genre> Genres { get; set; } = [];

        public List<Studio> Studios { get; set; } = [];

        public required bool Visible { get; set; }
    }
}