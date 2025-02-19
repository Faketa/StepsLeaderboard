namespace StepsLeaderboard.Application.Features.Teams.Queries;

using MediatR;
using StepsLeaderboard.Application.Features.Teams.DTOs;

public record GetTeamByIdQuery(Guid TeamId) : IRequest<TeamDto>;
