namespace StepsLeaderboard.Application.Features.Counters.Commands;

using MediatR;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a command to update the step count of a Counter.
/// </summary>
public record UpdateCounterStepsCommand : IRequest<Unit>
{
    [JsonIgnore]
    public Guid Id { get; }

    public int Steps { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCounterStepsCommand"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the Counter.</param>
    /// <param name="steps">The number of steps to be added.</param>
    public UpdateCounterStepsCommand(Guid id, int steps)
    {
        Id = id;
        Steps = steps;
    }
}
