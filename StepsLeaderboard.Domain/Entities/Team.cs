namespace StepsLeaderboard.Domain.Entities;

public class Team
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Team(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
