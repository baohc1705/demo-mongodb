using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.New.Commands.DeleteNews
{
    public class DeleteNewsByIdCommandHandler : IRequestHandler<DeleteNewsByIdCommand>
    {
        private readonly INewsRepository newsRepository;

        public DeleteNewsByIdCommandHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task Handle(DeleteNewsByIdCommand request, CancellationToken cancellationToken)
        {
            var news = await newsRepository.GetAsync(n => n.Id.Equals(request.id))
                ?? throw new ArgumentException($"Not found new with {request.id}");
            news.IsPublished = false;
            news.PublishedAt = null;
            news.UpdatedAt = DateTime.Now;

            await newsRepository.UpdateAsync(n => n.Id.Equals(news.Id), news);
        }
    }
}
