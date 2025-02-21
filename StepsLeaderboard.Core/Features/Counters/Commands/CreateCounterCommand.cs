using MediatR;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Text.Json.Serialization;

namespace StepsLeaderboard.Application.Features.Counters.Commands;

/// <summary>
/// Represents a command to create a new Counter.
/// </summary>
public record CreateCounterCommand(Guid Id, string Name, Guid TeamId) : IRequest<CounterDto>
{
    [JsonIgnore]
    public Guid Id { get; init; } = Guid.NewGuid();
}
