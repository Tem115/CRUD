

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Databases.Tables
{
    public class Game : TableBase<Guid>
    {
        public required string Name { get; set; }

        public List<Genre>? Genres { get; set; }

        public List<Studio>? Studios { get; set; }

        public bool Visable { get; set; } = true;
    }
}