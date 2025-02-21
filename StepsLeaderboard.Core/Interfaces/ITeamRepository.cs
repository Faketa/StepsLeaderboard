using StepsLeaderboard.Domain.Entities;

namespace StepsLeaderboard.Application.Interfaces;

/// <summary>
/// Defines repository methods for managing Team entities.
/// </summary>
public interface ITeamRepository
{
    /// <summary>
    /// Adds a new Team to the repository.
    /// </summary>
    /// <param name="team">The Team entity to add.</param>
    /// <returns>The created Team entity.</returns>
    Task<Team> AddTeam(Team team);

    /// <summary>
    /// Retrieves all Teams from the repository.
    /// </summary>
    /// <returns>A list of all Teams.</returns>
    Task<List<Team>> GetAllTeams();

    /// <summary>
    /// Retrieves a Team by its unique identifier.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team to retrieve.</param>
    /// <returns>The Team entity if found; otherwise, null.</returns>
    Task<Team?> GetTeamById(Guid teamId);

    /// <summary>
    /// Deletes a Team by its unique identifier.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team to delete.</param>
    Task DeleteTeam(Guid teamId);

    /// <summary>
    /// Checks whether a Team exists in the repository.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team to check.</param>
    /// <returns>True if the Team exists; otherwise, false.</returns>
    Task<bool> TeamExists(Guid teamId);
}
