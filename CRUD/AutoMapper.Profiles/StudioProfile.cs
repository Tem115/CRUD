using AutoMapper;
using CRUD.Models.OutputModels;
using Databases.Entities;

namespace CRUD.AutoMapper.Profiles
{
    public class StudioProfile : Profile
    {
        public StudioProfile()
        {
            CreateMap<Studio, StudioOutputModel>();
        } 
    }
}
