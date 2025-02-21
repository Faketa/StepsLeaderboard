using FluentValidation;
using StepsLeaderboard.Application.Features.Counters.Commands;

namespace StepsLeaderboard.Application.Features.Counters.Validators;

/// <summary>
/// Validates the <see cref="CreateCounterCommand"/> to ensure the input meets required constraints.
/// </summary>
public class CreateCounterValidator : AbstractValidator<CreateCounterCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCounterValidator"/> class.
    /// Defines validation rules for creating a Counter.
    /// </summary>
    public CreateCounterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Counter name is required.")
            .MaximumLength(50).WithMessage("Counter name cannot exceed 50 characters.");

        RuleFor(x => x.TeamId)
            .NotEmpty().WithMessage("Team ID is required.");
    }
}
