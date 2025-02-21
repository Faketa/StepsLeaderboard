using StepsLeaderboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Interfaces;

/// <summary>
/// Defines repository methods for managing Counters.
/// </summary>
public interface ICounterRepository
{
    /// <summary>
    /// Adds a new Counter to the repository.
    /// </summary>
    /// <param name="counter">The Counter entity to add.</param>
    /// <returns>The created Counter entity.</returns>
    Task<Counter> AddCounter(Counter counter);

    /// <summary>
    /// Retrieves all counters that belong to a specific team.
    /// </summary>
    /// <param name="teamId">The team ID to filter by.</param>
    /// <returns>A list of counters associated with the given team.</returns>
    Task<List<Counter>> GetCountersByTeam(Guid teamId);

    /// <summary>
    /// Retrieves a counter by its unique identifier.
    /// </summary>
    /// <param name="counterId">The ID of the counter to retrieve.</param>
    /// <returns>The counter entity if found, otherwise null.</returns>
    Task<Counter?> GetCounterById(Guid counterId);

    /// <summary>
    /// Increments the step count of a counter by a given value.
    /// </summary>
    /// <param name="counterId">The ID of the counter to update.</param>
    /// <param name="steps">The number of steps to add.</param>
    Task IncrementCounter(Guid counterId, int steps);

    /// <summary>
    /// Deletes a counter by its unique identifier.
    /// </summary>
    /// <param name="counterId">The ID of the counter to delete.</param>
    Task DeleteCounter(Guid counterId);

    /// <summary>
    /// Calculates the total steps taken by all counters in a specific team.
    /// </summary>
    /// <param name="teamId">The team ID to sum steps for.</param>
    /// <returns>The total step count for the team.</returns>
    Task<int> GetTotalStepsByTeam(Guid teamId);
}
