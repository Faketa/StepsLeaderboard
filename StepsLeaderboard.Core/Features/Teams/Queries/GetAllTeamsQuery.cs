using MediatR;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using System.Collections.Generic;

namespace StepsLeaderboard.Application.Features.Teams.Queries;

/// <summary>
/// Represents a query to retrieve all Teams, including their total step count.
/// </summary>
public record GetAllTeamsQuery() : IRequest<List<TeamSummaryDto>>;
