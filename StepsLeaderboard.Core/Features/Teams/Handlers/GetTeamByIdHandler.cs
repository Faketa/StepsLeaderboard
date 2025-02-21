using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Queries;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Teams.Handlers;

/// <summary>
/// Handles the retrieval of a Team by its unique identifier.
/// </summary>
public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdQuery, TeamDto>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ICounterRepository _counterRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTeamByIdHandler"/> class.
    /// </summary>
    /// <param name="teamRepository">The repository for Team entities.</param>
    /// <param name="counterRepository">The repository for Counter entities.</param>
    public GetTeamByIdHandler(ITeamRepository teamRepository, ICounterRepository counterRepository)
    {
        _teamRepository = teamRepository;
        _counterRepository = counterRepository;
    }

    /// <summary>
    /// Handles the request to retrieve a Team by its ID, including total step count and assigned Counters.
    /// </summary>
    /// <param name="request">The request containing the Team ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="TeamDto"/> representing the requested Team with total steps and Counters.
    /// </returns>
    /// <exception cref="KeyNotFoundException">Thrown when the specified Team does not exist.</exception>
    public async Task<TeamDto> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetTeamById(request.TeamId);
        if (team == null) throw new KeyNotFoundException("Team not found.");

        var totalSteps = await _counterRepository.GetTotalStepsByTeam(request.TeamId);
        var counters = await _counterRepository.GetCountersByTeam(request.TeamId);

        var counterDtos = counters.Select(c => new CounterDto(c.Id, c.Name, c.Steps, c.TeamId)).ToList();

        return new TeamDto(team.Id, team.Name, totalSteps, counterDtos);
    }
}
