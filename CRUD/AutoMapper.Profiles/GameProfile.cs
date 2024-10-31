using AutoMapper;
using CRUD.Models.InputModels;
using CRUD.Models.OutputModels;
using Databases.Tables;

namespace CRUD.AutoMapper.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameInputModel>().ReverseMap();
            CreateMap<Game, GameOutputModel>().ReverseMap();
        } 
    }
}
