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

[ApiController]
[Route("api/teams")]
public class TeamController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TeamController> _logger;

    public TeamController(IMediator mediator, ILogger<TeamController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand request)
    {
        _logger.LogInformation("Creating new team: {TeamName}", request.Name);
        var team = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
    }

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

    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        _logger.LogInformation("Fetching all teams");
        var teams = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(teams);
    }

    [HttpGet("team/{id}")]
    public async Task<IActionResult> GetCountersByTeam(Guid id)
    {
        _logger.LogInformation("Fetching all counters for team ID: {TeamId}", id);
        var counters = await _mediator.Send(new GetCountersByTeamQuery(id));
        return Ok(counters);
    }

    [HttpGet("{id}/total-steps")]
    public async Task<IActionResult> GetTotalStepsByTeam(Guid id)
    {
        _logger.LogInformation("Fetching total steps for team ID: {TeamId}", id);
        var totalSteps = await _mediator.Send(new GetTotalStepsByTeamQuery(id));
        return Ok(totalSteps);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        _logger.LogInformation("Deleting team with ID: {TeamId}", id);
        await _mediator.Send(new DeleteTeamCommand(id));
        return NoContent();
    }
}
