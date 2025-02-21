using MediatR;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Collections.Generic;

namespace StepsLeaderboard.Application.Features.Counters.Queries;

/// <summary>
/// Represents a query to retrieve all Counters associated with a specific Team.
/// </summary>
/// <param name="TeamId">The unique identifier of the Team whose Counters should be retrieved.</param>
public record GetCountersByTeamQuery(Guid TeamId) : IRequest<List<CounterDto>>;
