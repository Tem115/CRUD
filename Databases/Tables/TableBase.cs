using System.ComponentModel.DataAnnotations;

namespace Databases.Tables
{
    public class TableBase<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
    }
}
