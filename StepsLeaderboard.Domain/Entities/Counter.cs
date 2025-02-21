namespace StepsLeaderboard.Domain.Entities;

/// <summary>
/// Represents a Counter entity used to track step counts for a specific Team.
/// </summary>
public class Counter
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Steps { get; private set; }
    public Guid TeamId { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Counter"/> class.
    /// </summary>
    /// <param name="name">The name of the Counter.</param>
    /// <param name="teamId">The unique identifier of the Team to which the Counter belongs.</param>
    public Counter(string name, Guid teamId)
    {
        Id = Guid.NewGuid();
        Name = name;
        TeamId = teamId;
        Steps = 0;
    }

    /// <summary>
    /// Increments the step count of the Counter by a specified amount.
    /// </summary>
    /// <param name="stepCount">The number of steps to add.</param>
    public void Increment(int stepCount)
    {
        Steps += stepCount;
    }
}
