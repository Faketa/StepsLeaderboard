using MediatR;

namespace StepsLeaderboard.Application.Features.Teams.Commands;

/// <summary>
/// Represents a command to delete a Team by its unique identifier.
/// </summary>
/// <param name="TeamId">The unique identifier of the Team to be deleted.</param>
public record DeleteTeamCommand(Guid TeamId) : IRequest<Unit>;
