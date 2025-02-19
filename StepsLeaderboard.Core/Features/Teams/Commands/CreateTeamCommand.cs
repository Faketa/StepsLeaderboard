namespace StepsLeaderboard.Application.Features.Teams.Commands;

using MediatR;
using StepsLeaderboard.Application.Features.Teams.DTOs;

public record CreateTeamCommand(string Name) : IRequest<TeamDto>;
