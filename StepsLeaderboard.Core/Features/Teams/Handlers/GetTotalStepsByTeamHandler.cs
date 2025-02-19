namespace StepsLeaderboard.Application.Features.Counters.Handlers;

using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Queries;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetTotalStepsByTeamHandler : IRequestHandler<GetTotalStepsByTeamQuery, TotalStepsDto>
{
    private readonly ICounterRepository _counterRepository;

    public GetTotalStepsByTeamHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    public async Task<TotalStepsDto> Handle(GetTotalStepsByTeamQuery request, CancellationToken cancellationToken)
    {
        var counters = await _counterRepository.GetCountersByTeam(request.TeamId);
        var totalSteps = counters.Sum(c => c.Steps);
        return new TotalStepsDto(request.TeamId, totalSteps);
    }
}
