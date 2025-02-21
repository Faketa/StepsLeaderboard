namespace StepsLeaderboard.Domain.Entities;

/// <summary>
/// Represents a Team entity that groups multiple Counters together.
/// </summary>
public class Team
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Team"/> class.
    /// </summary>
    /// <param name="name">The name of the Team.</param>
    public Team(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
