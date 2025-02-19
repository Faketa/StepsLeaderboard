namespace StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Domain.Entities;

public interface ITeamRepository
{
    Task<Team> AddTeam(Team team);
    Task<List<Team>> GetAllTeams();
    Task<Team?> GetTeamById(Guid teamId);
    Task DeleteTeam(Guid teamId);

    Task<bool> TeamExists(Guid teamId);
}
