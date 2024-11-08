using AutoMapper;
using CRUD.Models.OutputModels;
using Databases.Entities;

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
