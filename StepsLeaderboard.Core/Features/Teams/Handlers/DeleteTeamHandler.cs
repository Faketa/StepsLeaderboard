using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Teams.Handlers;

public class DeleteTeamHandler : IRequestHandler<DeleteTeamCommand, Unit>
{
    private readonly ITeamRepository _teamRepository;

    public DeleteTeamHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetTeamById(request.TeamId);
        if (team == null) throw new KeyNotFoundException("Team not found.");

        await _teamRepository.DeleteTeam(request.TeamId);

        return Unit.Value;
    }
}
