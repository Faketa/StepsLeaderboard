using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Queries;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Teams.Handlers;

public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, List<TeamDto>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ICounterRepository _counterRepository;

    public GetAllTeamsHandler(ITeamRepository teamRepository, ICounterRepository counterRepository)
    {
        _teamRepository = teamRepository;
        _counterRepository = counterRepository;
    }

    public async Task<List<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.GetAllTeams();
        var teamDtos = new List<TeamDto>();

        foreach (var team in teams)
        {
            var totalSteps = await _counterRepository.GetTotalStepsByTeam(team.Id);
            teamDtos.Add(new TeamDto(team.Id, team.Name, totalSteps));
        }

        return teamDtos;
    }
}
