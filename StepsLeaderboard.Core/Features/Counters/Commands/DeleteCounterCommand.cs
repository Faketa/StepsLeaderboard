using MediatR;

namespace StepsLeaderboard.Application.Features.Counters.Commands;

/// <summary>
/// Represents a command to delete a Counter.
/// </summary>
/// <param name="CounterId">The unique identifier of the Counter to be deleted.</param>
public record DeleteCounterCommand(Guid CounterId) : IRequest<Unit>;
