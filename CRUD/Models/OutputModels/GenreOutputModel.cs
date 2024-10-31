

namespace CRUD.Models.OutputModels
{
    public class GenreOutputModel
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public List<GameOutputModel>? Games { get; set; }
    }
}
