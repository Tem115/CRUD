using AutoMapper;
using CRUD.Models.InputModels;
using CRUD.Models.OutputModels;
using Databases.Entities;

namespace CRUD.AutoMapper.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameOutputModel>();
        } 
    }
}
