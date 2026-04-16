using DemoMongoDb.Application.Features.Menus.DTOs;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Commands
{
    public record CreateMenuCommand(
        string Name,
        string? Description,
        string? Url,
        int Order,
        bool IsActive
    ) : IRequest<MenuDto>;
}
