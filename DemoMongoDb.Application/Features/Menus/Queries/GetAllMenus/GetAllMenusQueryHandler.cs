using AutoMapper;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Queries.GetAllMenus
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, IEnumerable<MenuDto>>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMapper mapper;

        public GetAllMenusQueryHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MenuDto>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var menus = await menuRepository.GetAsync();
            return mapper.Map<IEnumerable<MenuDto>>(menus);
        }
    }
}
