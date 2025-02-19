namespace StepsLeaderboard.Application.Features.Counters.Commands;

using MediatR;

public record IncrementCounterCommand(Guid CounterId, int Steps) : IRequest<Unit>;
