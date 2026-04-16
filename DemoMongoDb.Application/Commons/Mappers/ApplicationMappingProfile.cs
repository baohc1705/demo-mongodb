using AutoMapper;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Entities;

namespace DemoMongoDb.Application.Commons.Mappers
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() 
        {
            CreateMap<Menu, MenuDto>();
        }
    }
}
