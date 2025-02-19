using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Queries;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Counters.Handlers;

public class GetCountersByTeamHandler : IRequestHandler<GetCountersByTeamQuery, List<CounterDto>>
{
    private readonly ICounterRepository _counterRepository;

    public GetCountersByTeamHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    public async Task<List<CounterDto>> Handle(GetCountersByTeamQuery request, CancellationToken cancellationToken)
    {
        var counters = await _counterRepository.GetCountersByTeam(request.TeamId);
        return counters.Select(counter => new CounterDto(counter.Id, counter.Name, counter.Steps, counter.TeamId)).ToList();
    }
}
