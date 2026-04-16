using DemoMongoDb.Application.Features.Menus.Commands.CreateMenu;
using DemoMongoDb.Application.Features.Menus.Commands.DeleteMenu;
using DemoMongoDb.Application.Features.Menus.Commands.UpdateMenu;
using DemoMongoDb.Application.Features.Menus.Queries.GetAllMenus;
using DemoMongoDb.Application.Features.Menus.Queries.GetMenuById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoMongoDb.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ISender mediator;

        public MenuController(ISender mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await mediator.Send(new GetAllMenusQuery());
            return Ok(res);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await mediator.Send(new GetMenuByIdQuery() { Id = id});
            if (res == null) 
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMenuCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Post(string id, UpdateMenuCommand command)
        {
            if (id != command.Id) 
                return BadRequest("Id not same");
            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            await mediator.Send(new DeleteMenuCommand() { Id = id });
            return NoContent();
        }
    }
}
