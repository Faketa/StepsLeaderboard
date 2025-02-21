using FluentValidation;
using StepsLeaderboard.Application.Features.Counters.Commands;

namespace StepsLeaderboard.Application.Features.Counters.Validators;

/// <summary>
/// Validates the <see cref="DeleteCounterCommand"/> to ensure the input meets required constraints.
/// </summary>
public class DeleteCounterValidator : AbstractValidator<DeleteCounterCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteCounterValidator"/> class.
    /// Defines validation rules for deleting a Counter.
    /// </summary>
    public DeleteCounterValidator()
    {
        RuleFor(x => x.CounterId)
            .NotEmpty().WithMessage("Counter ID is required.");
    }
}
