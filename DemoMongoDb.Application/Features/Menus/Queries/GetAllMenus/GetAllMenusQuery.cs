using DemoMongoDb.Application.Features.Menus.DTOs;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Queries.GetAllMenus
{
    public class GetAllMenusQuery : IRequest<IEnumerable<MenuDto>>
    {
    }
}
