namespace StepsLeaderboard.Application.Features.Teams.Validators;

using FluentValidation;
using StepsLeaderboard.Application.Features.Teams.Commands;

public class CreateTeamValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Team name is required.")
            .MaximumLength(50).WithMessage("Team name cannot exceed 50 characters.");
    }
}
