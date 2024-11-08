using System.ComponentModel.DataAnnotations;

namespace Databases.Entities
{
    public class BaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
    }
}
