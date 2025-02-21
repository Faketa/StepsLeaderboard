using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Teams.Handlers;

/// <summary>
/// Handles the deletion of a Team.
/// </summary>
public class DeleteTeamHandler : IRequestHandler<DeleteTeamCommand, Unit>
{
    private readonly ITeamRepository _teamRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteTeamHandler"/> class.
    /// </summary>
    /// <param name="teamRepository">The repository for Team entities.</param>
    public DeleteTeamHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    /// <summary>
    /// Handles the request to delete a Team by its ID.
    /// </summary>
    /// <param name="request">The request containing the Team ID to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A completed task.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the specified Team does not exist.</exception>
    public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetTeamById(request.TeamId);
        if (team == null) throw new KeyNotFoundException($"Team with ID '{request.TeamId}' not found.");

        await _teamRepository.DeleteTeam(request.TeamId);

        return Unit.Value;
    }
}
