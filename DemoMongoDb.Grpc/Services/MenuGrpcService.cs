using DemoMongoDb.Application.Features.Menus.Commands.CreateMenu;
using DemoMongoDb.Application.Features.Menus.Commands.DeleteMenu;
using DemoMongoDb.Application.Features.Menus.Commands.UpdateMenu;
using DemoMongoDb.Application.Features.Menus.Queries.GetAllMenus;
using DemoMongoDb.Application.Features.Menus.Queries.GetMenuById;
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

        public override async Task<GetMenuByIdResponse> GetMenuById(GetMenuByIdRequest request, ServerCallContext context)
        {
            var menu = await mediator.Send(new GetMenuByIdQuery() { Id = request.Id });
            if (menu == null)
                return new GetMenuByIdResponse() { Found = false };
            return new GetMenuByIdResponse
            {
                Found = true,
                Menu = new MenuMessage
                {
                    Id = menu.Id,
                    Name = menu.Name,
                    Description = menu.Description,
                    Url = menu.Url,
                    Order = menu.Order,
                    IsActive = menu.IsActive,
                    CreatedAt = menu.CreatedAt.ToShortDateString(),
                    UpdatedAt = menu.UpdatedAt.ToShortDateString(),
                }
            };
        }

        public override async Task<CreateMenuResponse> CreateMenu(CreateMenuRequest request, ServerCallContext context)
        {
            var menuSaved = await mediator.Send(new CreateMenuCommand(
                request.Name,
                request.Description,
                request.Url,
                request.Order,
                request.IsActive
            ));

            return new CreateMenuResponse { Id = menuSaved.Id };
        }

        public override async Task<UpdateMenuResponse> UpdateMenu(UpdateMenuRequest request, ServerCallContext context)
        {
            var menuUpdated = await mediator.Send(new UpdateMenuCommand(
                request.Id,
                request.Name,
                request.Description,
                request.Url,
                request.Order,
                request.IsActive
            ));

            return new UpdateMenuResponse { Id = menuUpdated.Id };
        }

        public override async Task<DeleteMenuByIdResponse> DeleteMenuById(DeleteMenuByIdRequest request, ServerCallContext context)
        {
            try
            {
                await mediator.Send(new DeleteMenuCommand { Id = request.Id });
                return new DeleteMenuByIdResponse { Success = true }; 
            }
            catch (Exception ex)
            {
                return new DeleteMenuByIdResponse { Success = false };
            }
        }
    }
}
