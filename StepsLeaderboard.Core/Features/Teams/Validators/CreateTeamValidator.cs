using FluentValidation;
using StepsLeaderboard.Application.Features.Teams.Commands;

namespace StepsLeaderboard.Application.Features.Teams.Validators;

/// <summary>
/// Validates the <see cref="CreateTeamCommand"/> to ensure the input meets required constraints.
/// </summary>
public class CreateTeamValidator : AbstractValidator<CreateTeamCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTeamValidator"/> class.
    /// Defines validation rules for creating a Team.
    /// </summary>
    public CreateTeamValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Team name is required.")
            .MaximumLength(50).WithMessage("Team name cannot exceed 50 characters.");
    }
}
