using FluentValidation;
using FrList.server.Dtos;

namespace FrList.server.Validation;

public class CreatePersonDtoValidator : AbstractValidator<CreatePersonDto> {
    public CreatePersonDtoValidator() {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Must(name => !string.IsNullOrEmpty(name) && char.IsUpper(name[0]))
            .WithMessage("Name must start with a capital letter");

        RuleFor(x => x.Nick)
            .NotEmpty()
            .WithMessage("Nickname is required")
            .Must(nick => !string.IsNullOrEmpty(nick) && char.IsUpper(nick[0]))
            .WithMessage("Nickname must start with a capital letter");

        RuleFor(x => x.Age)
            .NotNull()
            .WithMessage("Age is required")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Age must be non-negative");

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date of birth is required")
            .Must(BeAValidDate)
            .WithMessage("Date of birth must be a valid date from the year 1900 onwards");
    }

    private bool BeAValidDate(string? date) {
        if (string.IsNullOrEmpty(date)) return false;
        if (DateOnly.TryParse(date, out DateOnly parsedDate)) {
            return parsedDate.Year >= 1900;
        }

        return false;
    }
}