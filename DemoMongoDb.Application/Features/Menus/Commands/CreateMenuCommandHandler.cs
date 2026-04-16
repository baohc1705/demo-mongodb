using AutoMapper;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Entities;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Commands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, MenuDto>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMapper mapper;

        public CreateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
        }

        public async Task<MenuDto> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = mapper.Map<Menu>(request);

            await menuRepository.CreateAsync(menu);

            return mapper.Map<MenuDto>(menu);
        }
    }
}
