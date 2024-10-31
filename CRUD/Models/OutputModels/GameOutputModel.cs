namespace CRUD.Models.OutputModels
{
    public class GameOutputModel
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public List<GenreOutputModel>? Genres { get; set; }

        public List<StudioOutputModel>? Studios { get; set; }
    }
}
