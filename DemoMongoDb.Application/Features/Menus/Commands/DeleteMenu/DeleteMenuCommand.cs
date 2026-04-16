using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommand : IRequest
    {
        public string Id { get; set; } = null!;
    }
}
