using AutoMapper;
using DemoMongoDb.Application.Features.New.DTOs;
using DemoMongoDb.Domain.Interfaces;
using MediatR;

namespace DemoMongoDb.Application.Features.New.Queries.GetAllNews
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<NewsDto>>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;
        public GetAllNewsQueryHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<NewsDto>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var res = await newsRepository.GetAsync();
            return mapper.Map<IEnumerable<NewsDto>>(res);
        }
    }
}
