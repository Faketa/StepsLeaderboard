using MediatR;
using StepsLeaderboard.Application.Features.Teams.DTOs;
using System.Collections.Generic;

namespace StepsLeaderboard.Application.Features.Teams.Queries;

public record GetAllTeamsQuery() : IRequest<List<TeamDto>>;
