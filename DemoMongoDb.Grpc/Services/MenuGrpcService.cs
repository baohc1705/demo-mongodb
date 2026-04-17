using DemoMongoDb.Application.Features.Menus.Queries.GetAllMenus;
using DemoMongoDb.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace DemoMongoDb.Grpc.Services
{
    public class MenuGrpcService : MenuService.MenuServiceBase
    {
        private readonly ISender mediator;

        public MenuGrpcService(ISender mediator)
        {
            this.mediator = mediator;
        }

        public override async Task<GetAllMenusResponse> GetAllMenus(GetAllMenusRequest request, ServerCallContext context)
        {
            var menus = await mediator.Send(new GetAllMenusQuery());
            var response = new GetAllMenusResponse();
            response.Items.AddRange(menus.Select(m => new MenuMessage
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Url = m.Url,
                Order = m.Order,
                IsActive = m.IsActive,
                CreatedAt = m.CreatedAt.ToShortDateString(),
                UpdatedAt = m.UpdatedAt.ToShortDateString(),
            }));

            return response;
        }
    }
}
