namespace StepsLeaderboard.Application.Features.Teams.Validators;

using FluentValidation;
using StepsLeaderboard.Application.Features.Teams.Commands;

public class DeleteTeamValidator : AbstractValidator<DeleteTeamCommand>
{
    public DeleteTeamValidator()
    {
        RuleFor(x => x.TeamId)
            .NotEmpty().WithMessage("Team ID is required.");
    }
}
