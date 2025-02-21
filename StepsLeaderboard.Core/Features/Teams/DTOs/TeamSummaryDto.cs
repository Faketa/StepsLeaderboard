namespace StepsLeaderboard.Application.Features.Teams.DTOs;

/// <summary>
/// Represents a summary Data Transfer Object (DTO) for a Team entity.
/// Used to return basic Team information without Counters.
/// </summary>
/// <param name="Id">The unique identifier of the Team.</param>
/// <param name="Name">The name of the Team.</param>
/// <param name="TotalSteps">The total steps accumulated by the Team.</param>
public record TeamSummaryDto(Guid Id, string Name, int TotalSteps);
