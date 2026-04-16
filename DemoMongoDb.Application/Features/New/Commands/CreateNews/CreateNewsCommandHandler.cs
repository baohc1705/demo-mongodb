using AutoMapper;
using DemoMongoDb.Application.Features.New.DTOs;
using DemoMongoDb.Domain.Entities;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.New.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, NewsDto>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;
        public CreateNewsCommandHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }
        public async Task<NewsDto> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = mapper.Map<News>(request);

            await newsRepository.CreateAsync(news);

            return mapper.Map<NewsDto>(news);
        }
    }
}
