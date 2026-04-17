using DemoMongoDb.Application.Features.New.Commands;
using DemoMongoDb.Application.Features.New.Commands.DeleteNews;
using DemoMongoDb.Application.Features.New.DTOs;
using DemoMongoDb.Application.Features.New.Queries.GetAllNews;
using DemoMongoDb.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace DemoMongoDb.Grpc.Services
{
    public class NewsGrpcService : NewsService.NewsServiceBase
    {
        private readonly ISender mediator;

        public NewsGrpcService(ISender mediator)
        {
            this.mediator = mediator;
        }

        public override async Task<GetAllNewsResponse> GetAllNews(GetAllNewsRequest request, ServerCallContext context)
        {
            var news = await mediator.Send(new GetAllNewsQuery());

            var response = new GetAllNewsResponse();

            response.Items.AddRange(news.Select(n => MapToMessage(n)));

            return response;
        }

        public override async Task<CreateNewsResponse> CreateNews(CreateNewsRequest request, ServerCallContext context)
        {
            var newsSaved = await mediator.Send(new CreateNewsCommand(
                 request.Title,
                 request.Slug,
                 request.Content,
                 request.Summary,
                 request.Thumbnail,
                 request.Author,
                 request.IsPublished,
                 request.Tags.ToList()
            ));
            return new CreateNewsResponse { Id = newsSaved.Id };
        }

        public override async Task<UpdateNewsResponse> UpdateNews(UpdateNewsRequest request, ServerCallContext context)
        {
            var newsSaved = await mediator.Send(new UpdateNewsCommand(
                request.Id,
                request.Title,
                request.Slug,
                request.Content,
                request.Summary,
                request.Thumbnail,
                request.Author,
                request.IsPublished,
                request.Tags.ToList()
            ));

            return new UpdateNewsResponse { Id = newsSaved.Id };
        }

        public override async Task<DeleteNewsByIdResponse> DeleteNewsById(DeleteNewsByIdRequest request, ServerCallContext context)
        {
            try
            {
                await mediator.Send(new DeleteNewsByIdCommand(request.Id));
                return new DeleteNewsByIdResponse { Success = true };
            }
            catch (Exception)
            {
                return new DeleteNewsByIdResponse { Success = false };
            }
        }

        private static NewsMessage MapToMessage(NewsDto n)
        {
            var msg = new NewsMessage
            {
                Id = n.Id,
                Title = n.Title,
                Slug = n.Slug,
                Content = n.Content,
                Summary = n.Summary,
                Thumbnail = n.Thumbnail,
                Author = n.Author,
                IsPublished = n.IsPublished,
                PublishedAt = n.PublishedAt?.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                CreatedAt = n.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                UpdatedAt = n.UpdatedAt.ToString("dd/MM/yyyy HH:mm:ss") ?? ""
            };
            msg.Tags.AddRange(n.Tags);
            return msg;
        }


    }
}
