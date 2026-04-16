using AutoMapper;
using DemoMongoDb.Application.Features.New.DTOs;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.New.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, NewsDto>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;

        public UpdateNewsCommandHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }

        public async Task<NewsDto> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await newsRepository.GetAsync(n => n.Id.Equals(request.Id))
                ?? throw new ArgumentException("Not found");


            news.Title = request.Title;
            news.Slug = request.Slug;
            news.Content = request.Content;
            news.Summary = request.Summary;
            news.Thumbnail = request.Thumbnail;
            news.Author = request.Author;
            news.Tags = request.Tags;

            if (request.IsPublished && !news.IsPublished)
                news.PublishedAt = DateTime.UtcNow;

            news.IsPublished = request.IsPublished;
            news.UpdatedAt = DateTime.UtcNow;

            await newsRepository.UpdateAsync(n => n.Id.Equals(news.Id), news);
            return mapper.Map<NewsDto>(news);
        }
    }
}
