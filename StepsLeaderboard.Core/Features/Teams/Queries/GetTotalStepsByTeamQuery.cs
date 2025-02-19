using MediatR;
using StepsLeaderboard.Application.Features.Counters.DTOs;

namespace StepsLeaderboard.Application.Features.Counters.Queries;

public record GetTotalStepsByTeamQuery(Guid TeamId) : IRequest<TotalStepsDto>;
