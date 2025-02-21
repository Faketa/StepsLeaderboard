using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Teams.Commands;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using StepsLeaderboard.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Teams.Handlers;

/// <summary>
/// Handles the creation of a new Team.
/// </summary>
public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, TeamDto>
{
    private readonly ITeamRepository _teamRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTeamHandler"/> class.
    /// </summary>
    /// <param name="teamRepository">The repository for Team entities.</param>
    public CreateTeamHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    /// <summary>
    /// Handles the request to create a new Team.
    /// </summary>
    /// <param name="request">The request containing the Team name.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The created Team as a <see cref="TeamDto"/>.</returns>
    public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team(request.Name);
        await _teamRepository.AddTeam(team);
        return new TeamDto(team.Id, team.Name, 0, null);
    }
}
