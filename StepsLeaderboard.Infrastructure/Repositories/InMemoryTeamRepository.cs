using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepsLeaderboard.Infrastructure.Repositories;

/// <summary>
/// An in-memory implementation of the <see cref="ITeamRepository"/> interface.
/// Stores and manages Team entities without using a database.
/// </summary>
public class InMemoryTeamRepository : ITeamRepository
{
    private readonly List<Team> _teams = new();

    /// <summary>
    /// Adds a new Team to the in-memory repository.
    /// </summary>
    /// <param name="team">The Team entity to add.</param>
    /// <returns>The added Team entity.</returns>
    public Task<Team> AddTeam(Team team)
    {
        _teams.Add(team);
        return Task.FromResult(team);
    }

    /// <summary>
    /// Retrieves all Teams stored in the in-memory repository.
    /// </summary>
    /// <returns>A list of all Teams.</returns>
    public Task<List<Team>> GetAllTeams()
    {
        return Task.FromResult(_teams);
    }

    /// <summary>
    /// Retrieves a Team by its unique identifier.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team.</param>
    /// <returns>The Team entity if found; otherwise, null.</returns>
    public Task<Team?> GetTeamById(Guid teamId)
    {
        return Task.FromResult(_teams.FirstOrDefault(t => t.Id == teamId));
    }

    /// <summary>
    /// Deletes a Team from the in-memory repository.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team to delete.</param>
    public Task DeleteTeam(Guid teamId)
    {
        _teams.RemoveAll(t => t.Id == teamId);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Checks whether a Team exists in the in-memory repository.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team to check.</param>
    /// <returns>True if the Team exists; otherwise, false.</returns>
    public Task<bool> TeamExists(Guid teamId)
    {
        return Task.FromResult(_teams.Any(t => t.Id == teamId));
    }
}
