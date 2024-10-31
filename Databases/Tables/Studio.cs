

namespace Databases.Tables
{
    public class Studio : TableBase<Guid>
    {
        public required string Name { get; set; }

        public List<Game>? Games { get; set; }
    }
}
