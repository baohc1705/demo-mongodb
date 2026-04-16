
using DemoMongoDb.Application.Features.New.DTOs;
using MediatR;

namespace DemoMongoDb.Application.Features.New.Commands;

public record UpdateNewsCommand(
    string Id,
    string Title,
    string Slug,
    string Content,
    string? Summary,
    string? Thumbnail,
    string? Author,
    bool IsPublished,
    List<string> Tags
) : IRequest<NewsDto>;