using MediatR;

namespace StepsLeaderboard.Application.Features.Teams.Commands;

public record DeleteTeamCommand(Guid TeamId) : IRequest<Unit>;
