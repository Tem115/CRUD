using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Tables
{
    public class GameStudio : TableBase<Guid>
    {
        public Guid GameId { get; set; }

        public Guid StudioId { get; set; }
    }
}
