using StepsLeaderboard.Application.Features.Counters.DTOs;

namespace StepsLeaderboard.Application.Features.Teams.DTOs;

/// <summary>
/// Represents a Data Transfer Object (DTO) for a Team entity.
/// Used to return Team data from API responses.
/// </summary>
/// <param name="Id">The unique identifier of the Team.</param>
/// <param name="Name">The name of the Team.</param>
/// <param name="TotalSteps">The total steps accumulated by the Team.</param>
/// <param name="Counters">A list of Counters associated with the Team.</param>
public record TeamDto(Guid Id, string Name, int TotalSteps, List<CounterDto> Counters);
