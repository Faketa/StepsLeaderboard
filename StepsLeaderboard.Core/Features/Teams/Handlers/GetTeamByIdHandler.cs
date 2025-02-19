namespace StepsLeaderboard.Application.Features.Teams.Handlers;

using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Queries;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using System.Threading;
using System.Threading.Tasks;

public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdQuery, TeamDto>
{
    private readonly ITeamRepository _teamRepository;

    public GetTeamByIdHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<TeamDto> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetTeamById(request.TeamId);
        if (team == null) throw new KeyNotFoundException("Team not found.");

        return new TeamDto(team.Id, team.Name, 0);
    }
}
