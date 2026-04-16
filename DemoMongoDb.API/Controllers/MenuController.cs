using DemoMongoDb.Application.Features.Menus.Queries.GetAllMenus;
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
    }
}
