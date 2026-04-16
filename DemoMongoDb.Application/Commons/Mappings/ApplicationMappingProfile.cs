using AutoMapper;
using DemoMongoDb.Application.Features.Menus.Commands.CreateMenu;
using DemoMongoDb.Application.Features.Menus.Commands.UpdateMenu;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Application.Features.New.Commands;
using DemoMongoDb.Application.Features.New.DTOs;
using DemoMongoDb.Domain.Entities;

namespace DemoMongoDb.Application.Commons.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Menu, MenuDto>().ReverseMap();

            CreateMap<CreateMenuCommand, Menu>();

            CreateMap<UpdateMenuCommand, Menu>();

            CreateMap<News, NewsDto>().ReverseMap();

            CreateMap<CreateNewsCommand, News>();
        }
    }
}
