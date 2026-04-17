using MediatR;

namespace DemoMongoDb.Application.Features.New.Commands.DeleteNews
{
    public record DeleteNewsByIdCommand (string id) : IRequest;
    
}
