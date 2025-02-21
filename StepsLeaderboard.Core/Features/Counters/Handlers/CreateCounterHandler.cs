namespace StepsLeaderboard.Application.Features.Counters.Handlers;

using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Commands;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using StepsLeaderboard.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

/// <summary>
/// Handles the creation of a new Counter.
/// Ensures that the Counter is assigned to only one Team.
/// </summary>
public class CreateCounterHandler : IRequestHandler<CreateCounterCommand, CounterDto>
{
    private readonly ICounterRepository _counterRepository;
    private readonly ITeamRepository _teamRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCounterHandler"/> class.
    /// </summary>
    /// <param name="counterRepository">Repository for Counter entities.</param>
    /// <param name="teamRepository">Repository for Team entities.</param>
    public CreateCounterHandler(ICounterRepository counterRepository, ITeamRepository teamRepository)
    {
        _counterRepository = counterRepository;
        _teamRepository = teamRepository;
    }

    /// <summary>
    /// Handles the request to create a new Counter.
    /// Ensures that the Counter does not already exist in another Team.
    /// </summary>
    /// <param name="request">The Counter creation command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created CounterDto.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the specified team does not exist.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the Counter is already assigned to another Team.</exception>
    public async Task<CounterDto> Handle(CreateCounterCommand request, CancellationToken cancellationToken)
    {
        var teamExists = await _teamRepository.TeamExists(request.TeamId);
        if (!teamExists)
        {
            throw new KeyNotFoundException("Cannot create a counter for a non-existent team.");
        }

        var existingCounter = await _counterRepository.GetCounterById(request.Id);
        if (existingCounter != null)
        {
            if (existingCounter.TeamId != request.TeamId)
            {
                throw new InvalidOperationException($"Counter with ID '{request.Id}' is already assigned to another team.");
            }
            else
            {
                throw new InvalidOperationException($"Counter with ID '{request.Id}' already exists in this team.");
            }
        }

        var counter = new Counter(request.Name, request.TeamId);
        await _counterRepository.AddCounter(counter);
        return new CounterDto(counter.Id, counter.Name, counter.Steps, counter.TeamId);
    }
}
