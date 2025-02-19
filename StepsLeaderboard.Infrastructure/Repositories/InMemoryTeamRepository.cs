namespace StepsLeaderboard.Infrastructure.Repositories;

using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class InMemoryTeamRepository : ITeamRepository
{
    private readonly List<Team> _teams = new();

    public Task<Team> AddTeam(Team team)
    {
        _teams.Add(team);
        return Task.FromResult(team);
    }

    public Task<List<Team>> GetAllTeams()
    {
        return Task.FromResult(_teams);
    }

    public Task<Team?> GetTeamById(Guid teamId)
    {
        return Task.FromResult(_teams.FirstOrDefault(t => t.Id == teamId));
    }

    public Task DeleteTeam(Guid teamId)
    {
        _teams.RemoveAll(t => t.Id == teamId);
        return Task.CompletedTask;
    }

    public Task<bool> TeamExists(Guid teamId)
    {
        return Task.FromResult(_teams.Any(t => t.Id == teamId));
    }
}
