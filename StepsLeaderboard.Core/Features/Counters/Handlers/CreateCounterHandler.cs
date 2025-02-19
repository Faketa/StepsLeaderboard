using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Commands;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using StepsLeaderboard.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Counters.Handlers;

public class CreateCounterHandler : IRequestHandler<CreateCounterCommand, CounterDto>
{
    private readonly ICounterRepository _counterRepository;
    private readonly ITeamRepository _teamRepository;

    public CreateCounterHandler(ICounterRepository counterRepository, ITeamRepository teamRepository)
    {
        _counterRepository = counterRepository;
        _teamRepository = teamRepository;
    }

    public async Task<CounterDto> Handle(CreateCounterCommand request, CancellationToken cancellationToken)
    {
        var teamExists = await _teamRepository.TeamExists(request.TeamId);
        if (!teamExists)
        {
            throw new KeyNotFoundException("Cannot create a counter for a non-existent team.");
        }

        var counter = new Counter(request.Name, request.TeamId);
        await _counterRepository.AddCounter(counter);
        return new CounterDto(counter.Id, counter.Name, counter.Steps, counter.TeamId);
    }
}
