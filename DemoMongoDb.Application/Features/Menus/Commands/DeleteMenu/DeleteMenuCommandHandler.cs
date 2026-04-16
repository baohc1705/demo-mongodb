using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand>
    {
        private readonly IMenuRepository menuRepository;

        public DeleteMenuCommandHandler(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await menuRepository.GetAsync(m => m.Id.Equals(request.Id))
                ?? throw new ArgumentException("Not found");
            menu.IsActive = false;
            menu.UpdatedAt = DateTime.UtcNow;
            await menuRepository.UpdateAsync(m => m.Id.Equals(menu.Id), menu);
            
        }
    }
}
