using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Queries;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Counters.Handlers;

/// <summary>
/// Handles the retrieval of a Counter by its unique identifier.
/// </summary>
public class GetCounterByIdHandler : IRequestHandler<GetCounterByIdQuery, CounterDto>
{
    private readonly ICounterRepository _counterRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCounterByIdHandler"/> class.
    /// </summary>
    /// <param name="counterRepository">The repository for Counter entities.</param>
    public GetCounterByIdHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    /// <summary>
    /// Handles the request to retrieve a Counter by its ID.
    /// </summary>
    /// <param name="request">The request containing the Counter ID to retrieve.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="CounterDto"/> representing the requested Counter if found; otherwise, null.
    /// </returns>
    public async Task<CounterDto> Handle(GetCounterByIdQuery request, CancellationToken cancellationToken)
    {
        var counter = await _counterRepository.GetCounterById(request.CounterId);
        if (counter == null) throw new KeyNotFoundException("Counter not found.");

        return new CounterDto(counter.Id, counter.Name, counter.Steps, counter.TeamId);
    }
}
