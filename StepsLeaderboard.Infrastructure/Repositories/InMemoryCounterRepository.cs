using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepsLeaderboard.Infrastructure.Repositories;

/// <summary>
/// An in-memory implementation of the <see cref="ICounterRepository"/> interface.
/// Stores and manages Counter entities without using a database.
/// </summary>
public class InMemoryCounterRepository : ICounterRepository
{
    private readonly List<Counter> _counters = new();

    /// <summary>
    /// Adds a new Counter to the in-memory repository.
    /// </summary>
    /// <param name="counter">The Counter entity to add.</param>
    /// <returns>The added Counter entity.</returns>
    public Task<Counter> AddCounter(Counter counter)
    {
        _counters.Add(counter);
        return Task.FromResult(counter);
    }

    /// <summary>
    /// Retrieves all Counters associated with a specific Team.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team.</param>
    /// <returns>A list of Counters belonging to the specified Team.</returns>
    public Task<List<Counter>> GetCountersByTeam(Guid teamId)
    {
        return Task.FromResult(_counters.Where(c => c.TeamId == teamId).ToList());
    }

    /// <summary>
    /// Retrieves a Counter by its unique identifier.
    /// </summary>
    /// <param name="counterId">The unique identifier of the Counter.</param>
    /// <returns>The Counter entity if found; otherwise, null.</returns>
    public Task<Counter?> GetCounterById(Guid counterId)
    {
        return Task.FromResult(_counters.FirstOrDefault(c => c.Id == counterId));
    }

    /// <summary>
    /// Increments the step count of a Counter.
    /// </summary>
    /// <param name="counterId">The unique identifier of the Counter.</param>
    /// <param name="steps">The number of steps to add.</param>
    public Task IncrementCounter(Guid counterId, int steps)
    {
        var counter = _counters.FirstOrDefault(c => c.Id == counterId);
        if (counter != null)
        {
            counter.Increment(steps);
        }
        return Task.CompletedTask;
    }

    /// <summary>
    /// Deletes a Counter from the in-memory repository.
    /// </summary>
    /// <param name="counterId">The unique identifier of the Counter to delete.</param>
    public Task DeleteCounter(Guid counterId)
    {
        _counters.RemoveAll(c => c.Id == counterId);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Retrieves the total number of steps taken by all Counters associated with a specific Team.
    /// </summary>
    /// <param name="teamId">The unique identifier of the Team.</param>
    /// <returns>The total step count for the Team.</returns>
    public Task<int> GetTotalStepsByTeam(Guid teamId)
    {
        var totalSteps = _counters.Where(c => c.TeamId == teamId).Sum(c => c.Steps);
        return Task.FromResult(totalSteps);
    }
}
