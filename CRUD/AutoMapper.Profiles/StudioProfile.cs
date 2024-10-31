using AutoMapper;
using CRUD.Models.OutputModels;
using Databases.Tables;

namespace CRUD.AutoMapper.Profiles
{
    public class StudioProfile : Profile
    {
        public StudioProfile()
        {
            CreateMap<Studio, StudioOutputModel>().ReverseMap();
        } 
    }
}
