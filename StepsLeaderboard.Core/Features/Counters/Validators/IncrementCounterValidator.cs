namespace StepsLeaderboard.Application.Features.Counters.Validators;

using FluentValidation;
using StepsLeaderboard.Application.Features.Counters.Commands;

public class IncrementCounterValidator : AbstractValidator<IncrementCounterCommand>
{
    public IncrementCounterValidator()
    {
        RuleFor(x => x.Steps)
            .GreaterThan(0).WithMessage("Steps must be greater than 0.")
            .LessThanOrEqualTo(10000).WithMessage("Steps cannot exceed 10,000 in a single request.");

        RuleFor(x => x.CounterId)
            .NotEmpty().WithMessage("Counter ID is required.");
    }
}
