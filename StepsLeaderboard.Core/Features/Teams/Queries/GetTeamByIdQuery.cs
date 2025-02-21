using MediatR;
using StepsLeaderboard.Application.Features.Teams.DTOs;

namespace StepsLeaderboard.Application.Features.Teams.Queries;

/// <summary>
/// Represents a query to retrieve a Team by its unique identifier.
/// </summary>
/// <param name="TeamId">The unique identifier of the Team to retrieve.</param>
public record GetTeamByIdQuery(Guid TeamId) : IRequest<TeamDto>;
