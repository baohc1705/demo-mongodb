using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.Menus.Queries.GetAllMenus
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, IEnumerable<MenuDto>>
    {
        private readonly IMenuRepository menuRepository;

        public GetAllMenusQueryHandler(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuDto>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var menus = await menuRepository.GetAsync();

            return menus.Select(m => new MenuDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Url = m.Url,
                Order = m.Order,
                IsActive = m.IsActive,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt,
            });
        }
    }
}
