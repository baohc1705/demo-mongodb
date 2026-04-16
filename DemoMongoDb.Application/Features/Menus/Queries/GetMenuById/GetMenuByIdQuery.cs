using DemoMongoDb.Application.Features.Menus.DTOs;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Queries.GetMenuById
{
    public class GetMenuByIdQuery : IRequest<MenuDto>
    {
        public string Id { get; set; } = null!;
    }
}
