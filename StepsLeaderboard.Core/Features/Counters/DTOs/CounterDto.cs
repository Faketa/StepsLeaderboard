namespace StepsLeaderboard.Application.Features.Counters.DTOs;

public record CounterDto(Guid Id, string Name, int Steps, Guid TeamId);
