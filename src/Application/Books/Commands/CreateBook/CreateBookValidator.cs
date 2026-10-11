using FluentValidation;

namespace Application.Books.Commands.CreateBook;

public class CreateBookValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(x => x.Publisher)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Authors)
            .NotEmpty();

        RuleForEach(x => x.Authors)
            .NotEmpty()
            .MaximumLength(200);

        RuleForEach(x => x.Categories)
            .MaximumLength(200);

        RuleForEach(x => x.IndustryIdentifiers)
            .ChildRules(identifier =>
            {
                identifier.RuleFor(x => x.Type).NotEmpty().MaximumLength(50);
                identifier.RuleFor(x => x.Identifier).NotEmpty().MaximumLength(80);
            });
    }
}
