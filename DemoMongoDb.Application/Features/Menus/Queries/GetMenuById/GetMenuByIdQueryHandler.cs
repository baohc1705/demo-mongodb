using AutoMapper;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Queries.GetMenuById
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, MenuDto>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMapper mapper;

        public GetMenuByIdQueryHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
        }

        public async Task<MenuDto> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var menu = await menuRepository.GetAsync(m => m.Id.Equals(request.Id));
            return mapper.Map<MenuDto>(menu);
        }
    }
}
