using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepsLeaderboard.Infrastructure.Repositories;

public class InMemoryCounterRepository : ICounterRepository
{
    private readonly List<Counter> _counters = new();

    public Task<Counter> AddCounter(Counter counter)
    {
        _counters.Add(counter);
        return Task.FromResult(counter);
    }

    public Task<List<Counter>> GetCountersByTeam(Guid teamId)
    {
        return Task.FromResult(_counters.Where(c => c.TeamId == teamId).ToList());
    }

    public Task<Counter?> GetCounterById(Guid counterId)
    {
        return Task.FromResult(_counters.FirstOrDefault(c => c.Id == counterId));
    }

    public Task IncrementCounter(Guid counterId, int steps)
    {
        var counter = _counters.FirstOrDefault(c => c.Id == counterId);
        if (counter != null)
        {
            counter.Increment(steps);
        }
        return Task.CompletedTask;
    }

    public Task DeleteCounter(Guid counterId)
    {
        _counters.RemoveAll(c => c.Id == counterId);
        return Task.CompletedTask;
    }

    public Task<int> GetTotalStepsByTeam(Guid teamId)
    {
        var totalSteps = _counters.Where(c => c.TeamId == teamId).Sum(c => c.Steps);
        return Task.FromResult(totalSteps);
    }
}
