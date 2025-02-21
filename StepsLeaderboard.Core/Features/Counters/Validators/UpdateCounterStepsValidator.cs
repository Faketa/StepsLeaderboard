using FluentValidation;
using StepsLeaderboard.Application.Features.Counters.Commands;

namespace StepsLeaderboard.Application.Features.Counters.Validators;

/// <summary>
/// Validates the <see cref="UpdateCounterStepsCommand"/> to ensure the input meets required constraints.
/// </summary>
public class UpdateCounterStepsValidator : AbstractValidator<UpdateCounterStepsCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCounterStepsValidator"/> class.
    /// Defines validation rules for updating the step count of a Counter.
    /// </summary>
    public UpdateCounterStepsValidator()
    {
        RuleFor(x => x.Steps)
            .GreaterThan(0).WithMessage("Steps must be greater than 0.")
            .LessThanOrEqualTo(10000).WithMessage("Steps cannot exceed 10,000 in a single request.");

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Counter ID is required.");
    }
}
