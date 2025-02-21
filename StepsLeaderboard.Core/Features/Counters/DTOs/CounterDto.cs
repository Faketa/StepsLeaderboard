namespace StepsLeaderboard.Application.Features.Counters.DTOs;

/// <summary>
/// Represents a Data Transfer Object (DTO) for a Counter entity.
/// Used to return Counter data from API responses.
/// </summary>
/// <param name="Id">The unique identifier of the Counter.</param>
/// <param name="Name">The name of the Counter.</param>
/// <param name="Steps">The current step count associated with the Counter.</param>
/// <param name="TeamId">The unique identifier of the Team to which the Counter belongs.</param>
public record CounterDto(Guid Id, string Name, int Steps, Guid TeamId);
