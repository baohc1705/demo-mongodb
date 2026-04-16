using AutoMapper;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, MenuDto>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMapper mapper;

        public UpdateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
        }

        public async Task<MenuDto> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await menuRepository.GetAsync(m => m.Id.Equals(request.Id))
                ?? throw new ArgumentException("Not found");

            menu.Name = request.Name;
            menu.Description = request.Description;
            menu.Url = request.Url;
            menu.Order = request.Order;
            menu.IsActive = request.IsActive;
            menu.UpdatedAt = DateTime.UtcNow;

            await menuRepository.UpdateAsync(m => m.Id.Equals(menu.Id),menu);

            return mapper.Map<MenuDto>(menu);
        }
    }
}
