namespace StepsLeaderboard.Domain.Entities;

public class Counter
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Steps { get; private set; }
    public Guid TeamId { get; private set; }

    public Counter(string name, Guid teamId)
    {
        Id = Guid.NewGuid();
        Name = name;
        TeamId = teamId;
        Steps = 0;
    }

    public void Increment(int stepCount)
    {
        Steps += stepCount;
    }
}
