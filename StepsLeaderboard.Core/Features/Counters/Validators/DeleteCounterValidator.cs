namespace StepsLeaderboard.Application.Features.Counters.Validators;

using FluentValidation;
using StepsLeaderboard.Application.Features.Counters.Commands;

public class DeleteCounterValidator : AbstractValidator<DeleteCounterCommand>
{
    public DeleteCounterValidator()
    {
        RuleFor(x => x.CounterId)
            .NotEmpty().WithMessage("Counter ID is required.");
    }
}
