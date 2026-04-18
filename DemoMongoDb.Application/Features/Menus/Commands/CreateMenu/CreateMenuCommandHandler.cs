using AutoMapper;
using DemoMongoDb.Application.Commons;
using DemoMongoDb.Application.Features.Menus.DTOs;
using DemoMongoDb.Domain.Entities;
using DemoMongoDb.Domain.Events;
using DemoMongoDb.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DemoMongoDb.Application.Features.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, MenuDto>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;
        private readonly ILogger<CreateMenuCommandHandler> logger;

        public CreateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper, IEventBus eventBus, ILogger<CreateMenuCommandHandler> logger)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
            this.eventBus = eventBus;
            this.logger = logger;
        }

        public async Task<MenuDto> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("▶ [Handler] Bắt đầu xử lý CreateMenuCommand");

            var menu = mapper.Map<Menu>(request);

            menu.UpdatedAt = DateTime.UtcNow;
            menu.CreatedAt = DateTime.UtcNow;

            await menuRepository.CreateAsync(menu);

            logger.LogInformation("💾 [Handler] Đã lưu MongoDB → Id={Id}", menu.Id);
            logger.LogInformation("📤 [Handler] Đang publish MenuCreatedEvent lên RabbitMQ...");

            await eventBus.PublishAsync(new MenuCreatedEvent(
                menu.Id,
                menu.Name,
                menu.Url,
                menu.Order,
                menu.IsActive,
                menu.CreatedAt
            ), cancellationToken);

            logger.LogInformation("✅ [Handler] Publish xong → trả về Id cho client ngay");

            return mapper.Map<MenuDto>(menu);
        }
    }
}
