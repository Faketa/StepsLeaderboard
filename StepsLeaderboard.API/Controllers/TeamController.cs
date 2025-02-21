using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using StepsLeaderboard.Application.Features.Teams.Commands;
using StepsLeaderboard.Application.Features.Teams.Queries;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using StepsLeaderboard.Application.Features.Counters.Queries;

namespace StepsLeaderboard.API.Controllers;

/// <summary>
/// API Controller for managing Teams.
/// </summary>
[ApiController]
[Route("api/teams")]
public class TeamController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TeamController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="TeamController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator instance.</param>
    /// <param name="logger">Logger instance.</param>
    public TeamController(IMediator mediator, ILogger<TeamController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new Team.
    /// </summary>
    /// <param name="request">The Team creation request.</param>
    /// <returns>The created Team.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand request)
    {
        _logger.LogInformation("Creating new team: {TeamName}", request.Name);
        var team = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
    }

    /// <summary>
    /// Retrieves a Team by ID.
    /// </summary>
    /// <param name="id">The ID of the Team.</param>
    /// <returns>The requested Team.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(Guid id)
    {
        _logger.LogInformation("Fetching team with ID: {TeamId}", id);
        var team = await _mediator.Send(new GetTeamByIdQuery(id));

        if (team == null)
        {
            _logger.LogWarning("Team with ID {TeamId} not found", id);
            return NotFound(new { Message = "Team not found." });
        }

        return Ok(team);
    }

    /// <summary>
    /// Retrieves all Teams.
    /// </summary>
    /// <returns>List of Teams.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        _logger.LogInformation("Fetching all teams");
        var teams = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(teams);
    }

    /// <summary>
    /// Deletes a Team.
    /// </summary>
    /// <param name="id">The ID of the Team to delete.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        _logger.LogInformation("Deleting team with ID: {TeamId}", id);
        await _mediator.Send(new DeleteTeamCommand(id));
        return NoContent();
    }
}
