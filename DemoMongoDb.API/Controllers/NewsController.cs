using DemoMongoDb.Application.Features.New.Commands;
using DemoMongoDb.Application.Features.New.Commands.DeleteNews;
using DemoMongoDb.Application.Features.New.Queries.GetAllNews;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMongoDb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ISender mediator;

        public NewsController(ISender mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await mediator.Send(new GetAllNewsQuery());
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNewsCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, UpdateNewsCommand command)
        {
            if (id != command.Id) return BadRequest();
            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await mediator.Send(new DeleteNewsByIdCommand(id));
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
