using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Queries;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Teams.Handlers;

/// <summary>
/// Handles the retrieval of all Teams.
/// </summary>
public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, List<TeamSummaryDto>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ICounterRepository _counterRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllTeamsHandler"/> class.
    /// </summary>
    /// <param name="teamRepository">The repository for Team entities.</param>
    /// <param name="counterRepository">The repository for Counter entities.</param>
    public GetAllTeamsHandler(ITeamRepository teamRepository, ICounterRepository counterRepository)
    {
        _teamRepository = teamRepository;
        _counterRepository = counterRepository;
    }

    /// <summary>
    /// Handles the request to retrieve all Teams, including their total step count.
    /// </summary>
    /// <param name="request">The request to get all Teams.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A list of <see cref="TeamSummaryDto"/> objects representing all Teams with their total steps.
    /// </returns>
    public async Task<List<TeamSummaryDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.GetAllTeams();
        var teamDtos = new List<TeamSummaryDto>();

        foreach (var team in teams)
        {
            var totalSteps = await _counterRepository.GetTotalStepsByTeam(team.Id);
            teamDtos.Add(new TeamSummaryDto(team.Id, team.Name, totalSteps));
        }

        return teamDtos;
    }
}
