using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Queries;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Counters.Handlers;

/// <summary>
/// Handles the retrieval of all Counters associated with a specific Team.
/// </summary>
public class GetCountersByTeamHandler : IRequestHandler<GetCountersByTeamQuery, List<CounterDto>>
{
    private readonly ICounterRepository _counterRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCountersByTeamHandler"/> class.
    /// </summary>
    /// <param name="counterRepository">The repository for Counter entities.</param>
    public GetCountersByTeamHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    /// <summary>
    /// Handles the request to retrieve all Counters associated with a specific Team.
    /// </summary>
    /// <param name="request">The request containing the Team ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A list of <see cref="CounterDto"/> objects representing the Counters associated with the specified Team.
    /// Returns an empty list if no Counters exist for the given Team.
    /// </returns>
    public async Task<List<CounterDto>> Handle(GetCountersByTeamQuery request, CancellationToken cancellationToken)
    {
        var counters = await _counterRepository.GetCountersByTeam(request.TeamId);
        return counters.Select(counter => new CounterDto(counter.Id, counter.Name, counter.Steps, counter.TeamId)).ToList();
    }
}
