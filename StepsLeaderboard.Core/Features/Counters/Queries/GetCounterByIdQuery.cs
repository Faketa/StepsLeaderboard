using MediatR;
using StepsLeaderboard.Application.Features.Counters.DTOs;

namespace StepsLeaderboard.Application.Features.Counters.Queries;

/// <summary>
/// Represents a query to retrieve a Counter by its unique identifier.
/// </summary>
/// <param name="CounterId">The unique identifier of the Counter to retrieve.</param>
public record GetCounterByIdQuery(Guid CounterId) : IRequest<CounterDto>;
