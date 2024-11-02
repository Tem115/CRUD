

namespace Databases.Tables
{
    public class Genre : TableBase<Guid>
    {
        public required string Name { get; set; }

        public List<Game> Games { get; set; } = [];
    }
}