namespace StepsLeaderboard.Application.Features.Counters.Validators;
using FluentValidation;
using StepsLeaderboard.Application.Features.Counters.Commands;

public class CreateCounterValidator : AbstractValidator<CreateCounterCommand>
{
    public CreateCounterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Counter name is required.")
            .MaximumLength(50).WithMessage("Counter name cannot exceed 50 characters.");

        RuleFor(x => x.TeamId)
            .NotEmpty().WithMessage("Team ID is required.");
    }
}
