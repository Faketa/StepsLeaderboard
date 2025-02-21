using FluentValidation;
using StepsLeaderboard.Application.Features.Teams.Commands;

namespace StepsLeaderboard.Application.Features.Teams.Validators;

/// <summary>
/// Validates the <see cref="DeleteTeamCommand"/> to ensure the input meets required constraints.
/// </summary>
public class DeleteTeamValidator : AbstractValidator<DeleteTeamCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteTeamValidator"/> class.
    /// Defines validation rules for deleting a Team.
    /// </summary>
    public DeleteTeamValidator()
    {
        RuleFor(x => x.TeamId)
            .NotEmpty().WithMessage("Team ID is required.");
    }
}
