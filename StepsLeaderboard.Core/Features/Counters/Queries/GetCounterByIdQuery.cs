namespace StepsLeaderboard.Application.Features.Counters.Queries;

using MediatR;
using StepsLeaderboard.Application.Features.Counters.DTOs;

public record GetCounterByIdQuery(Guid CounterId) : IRequest<CounterDto>;
