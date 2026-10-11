using Api.Contracts;
using Application.Books.Commands.CreateBook;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ISender _sender;

    public BooksController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<APIResponse<BookDto>>> Create(
        [FromBody] CreateBookRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateBookCommand(
            request.Title,
            request.Authors ?? Array.Empty<string>(),
            request.Publisher,
            request.PublishedDate,
            request.Description,
            request.IndustryIdentifiers?
                .Select(identifier => new IndustryIdentifierInput(identifier.Type, identifier.Identifier))
                .ToArray() ?? Array.Empty<IndustryIdentifierInput>(),
            request.PageCount,
            request.PrintedPageCount,
            request.PrintType,
            request.Categories ?? Array.Empty<string>(),
            request.MaturityRating,
            request.AllowAnonLogging,
            request.ContentVersion,
            request.PanelizationSummary is null
                ? null
                : new PanelizationSummaryInput(
                    request.PanelizationSummary.ContainsEpubBubbles,
                    request.PanelizationSummary.ContainsImageBubbles),
            request.ImageLinks is null
                ? null
                : new ImageLinksInput(
                    request.ImageLinks.SmallThumbnail,
                    request.ImageLinks.Thumbnail,
                    request.ImageLinks.Small,
                    request.ImageLinks.Medium,
                    request.ImageLinks.Large,
                    request.ImageLinks.ExtraLarge),
            request.Language);

        var result = await _sender.Send(command, cancellationToken);

        return StatusCode(StatusCodes.Status201Created, APIResponse<BookDto>.Ok(result, "Book created successfully."));
    }
}
