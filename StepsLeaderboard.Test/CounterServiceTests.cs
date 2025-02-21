using NUnit.Framework;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using StepsLeaderboard.Application.Features.Counters.Commands;
using StepsLeaderboard.Application.Features.Counters.Handlers;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Domain.Entities;

namespace StepsLeaderboard.Test;

public class CounterServiceTests
{
    private Mock<ICounterRepository> _counterRepositoryMock;
    private Mock<ITeamRepository> _teamRepositoryMock;
    private CreateCounterHandler _createCounterHandler;

    [SetUp]
    public void Setup()
    {
        _counterRepositoryMock = new Mock<ICounterRepository>();
        _teamRepositoryMock = new Mock<ITeamRepository>();
        _createCounterHandler = new CreateCounterHandler(_counterRepositoryMock.Object, _teamRepositoryMock.Object);
    }

    [Test]
    public void GetCounterById_ShouldReturnCounter_WhenExists()
    {
        var command = new CreateCounterCommand(Guid.NewGuid(), "Daily Steps", Guid.NewGuid());
        var existingCounter = new Counter(command.Name, command.TeamId);

        _counterRepositoryMock.Setup(repo => repo.GetCounterById(command.Id))
                                .ReturnsAsync(existingCounter as Counter);

        var result = _counterRepositoryMock.Object.GetCounterById(command.Id).Result;

        Assert.IsNotNull(result);
        Assert.AreEqual(command.Name, result.Name);
        Assert.AreEqual(command.TeamId, result.TeamId);
    }

    [Test]
    public void CreateCounter_ShouldFail_WhenCounterAlreadyAssignedToAnotherTeam()
    {
        var command = new CreateCounterCommand(Guid.NewGuid(), "Daily Steps", Guid.NewGuid());
        var existingCounter = new Counter(command.Name, Guid.NewGuid());

        _teamRepositoryMock.Setup(repo => repo.TeamExists(command.TeamId)).ReturnsAsync(true);
        _counterRepositoryMock.Setup(repo => repo.GetCounterById(command.Id)).ReturnsAsync((Counter?)existingCounter);

        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _createCounterHandler.Handle(command, CancellationToken.None));
    }

    [Test]
    public void CreateCounter_ShouldFail_WhenTeamDoesNotExist()
    {
        var command = new CreateCounterCommand(Guid.NewGuid(), "Daily Steps", Guid.NewGuid());

        _teamRepositoryMock.Setup(repo => repo.TeamExists(command.TeamId)).ReturnsAsync(false);

        Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            await _createCounterHandler.Handle(command, CancellationToken.None));
    }
}
