using NUnit.Framework;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using StepsLeaderboard.Application.Features.Teams.Queries;
using StepsLeaderboard.Application.Features.Teams.Handlers;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Domain.Entities;

namespace StepsLeaderboard.Test;

public class TeamServiceTests
{
    private Mock<ITeamRepository> _teamRepositoryMock;
    private Mock<ICounterRepository> _counterRepositoryMock;
    private GetTeamByIdHandler _getTeamByIdHandler;

    [SetUp]
    public void Setup()
    {
        _teamRepositoryMock = new Mock<ITeamRepository>();
        _counterRepositoryMock = new Mock<ICounterRepository>();
        _getTeamByIdHandler = new GetTeamByIdHandler(_teamRepositoryMock.Object, _counterRepositoryMock.Object);
    }

    [Test]
    public async Task GetTeamById_ShouldIncludeTotalSteps()
    {
        var teamId = Guid.NewGuid();
        var team = new Team("Team Alpha");
        var totalSteps = 12000;

        _teamRepositoryMock.Setup(repo => repo.GetTeamById(teamId)).ReturnsAsync(team);
        _counterRepositoryMock.Setup(repo => repo.GetTotalStepsByTeam(teamId)).ReturnsAsync(totalSteps);

        _counterRepositoryMock.Setup(repo => repo.GetCountersByTeam(teamId)).ReturnsAsync(new List<Counter>());

        var query = new GetTeamByIdQuery(teamId);
        var result = await _getTeamByIdHandler.Handle(query, CancellationToken.None);

        Assert.AreEqual(team.Name, result.Name);
        Assert.AreEqual(totalSteps, result.TotalSteps);
    }

    [Test]
    public void GetTeamById_ShouldThrowException_WhenTeamNotFound()
    {
        var teamId = Guid.NewGuid();
        _teamRepositoryMock.Setup(repo => repo.GetTeamById(teamId)).ReturnsAsync((Team)null);

        var query = new GetTeamByIdQuery(teamId);

        Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            await _getTeamByIdHandler.Handle(query, CancellationToken.None));
    }
}
