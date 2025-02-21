using MediatR;
using StepsLeaderboard.Application.Features.Teams.DTOs;

namespace StepsLeaderboard.Application.Features.Teams.Commands;

/// <summary>
/// Represents a command to create a new Team.
/// </summary>
/// <param name="Name">The name of the Team.</param>
public record CreateTeamCommand(string Name) : IRequest<TeamDto>;
