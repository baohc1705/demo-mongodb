using DemoMongoDb.Application.Features.Menus.DTOs;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Commands.UpdateMenu
{
    public record UpdateMenuCommand (
        string Id,
        string Name,
        string? Description,
        string? Url,
        int Order,
        bool IsActive
    ) : IRequest<MenuDto>;
}
