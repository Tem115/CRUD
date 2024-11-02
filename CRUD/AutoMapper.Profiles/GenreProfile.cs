using AutoMapper;
using CRUD.Models.OutputModels;
using Databases.Tables;

namespace CRUD.AutoMapper.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreOutputModel>();
        } 
    }
}
