using DemoMongoDb.Application.Features.New.DTOs;
using MediatR;

namespace DemoMongoDb.Application.Features.New.Queries.GetAllNews
{
    public class GetAllNewsQuery : IRequest<IEnumerable<NewsDto>>
    {
    }
}
