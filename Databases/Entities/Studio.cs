

namespace Databases.Entities
{
    public class Studio : BaseEntity<Guid>
    {
        public required string Name { get; set; }

        public List<Game> Games { get; set; } = [];
    }
}
