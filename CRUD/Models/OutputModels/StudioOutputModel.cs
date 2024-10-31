

namespace CRUD.Models.OutputModels
{
    public class StudioOutputModel
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public List<GameOutputModel>? Games { get; set; }
    }
}
