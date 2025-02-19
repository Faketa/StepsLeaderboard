namespace StepsLeaderboard.Application.Features.Counters.Commands;
using MediatR;
using StepsLeaderboard.Application.Features.Counters.DTOs;

public record CreateCounterCommand(string Name, Guid TeamId) : IRequest<CounterDto>;
