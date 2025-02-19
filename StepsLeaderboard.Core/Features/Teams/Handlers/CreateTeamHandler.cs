namespace StepsLeaderboard.Application.Features.Teams.Handlers;

using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Commands;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using StepsLeaderboard.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, TeamDto>
{
    private readonly ITeamRepository _teamRepository;

    public CreateTeamHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team(request.Name);
        await _teamRepository.AddTeam(team);
        return new TeamDto(team.Id, team.Name, 0);
    }
}
