namespace StepsLeaderboard.Application.Features.Counters.Queries;

using MediatR;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Collections.Generic;

public record GetCountersByTeamQuery(Guid TeamId) : IRequest<List<CounterDto>>;
