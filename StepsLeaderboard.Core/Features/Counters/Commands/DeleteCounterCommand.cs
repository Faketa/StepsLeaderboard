using MediatR;

namespace StepsLeaderboard.Application.Features.Counters.Commands;

public record DeleteCounterCommand(Guid CounterId) : IRequest<Unit>;
