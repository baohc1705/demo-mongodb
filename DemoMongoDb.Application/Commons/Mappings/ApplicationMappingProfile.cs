using AutoMapper;
using DemoMongoDb.Application.Features.Menus.Commands;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Entities;

namespace DemoMongoDb.Application.Commons.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Menu, MenuDto>().ReverseMap();

            CreateMap<CreateMenuCommand, Menu>();
        }
    }
}
