using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Counters.Handlers;

/// <summary>
/// Handles the update of step counts for an existing Counter.
/// </summary>
public class UpdateCounterStepsHandler : IRequestHandler<UpdateCounterStepsCommand, Unit>
{
    private readonly ICounterRepository _counterRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCounterStepsHandler"/> class.
    /// </summary>
    /// <param name="counterRepository">The repository for Counter entities.</param>
    public UpdateCounterStepsHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    /// <summary>
    /// Handles the request to update the step count of a Counter.
    /// </summary>
    /// <param name="request">The request containing the Counter ID and the step count to increment.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A completed task with <see cref="Unit.Value"/>.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the specified Counter does not exist.</exception>
    public async Task<Unit> Handle(UpdateCounterStepsCommand request, CancellationToken cancellationToken)
    {
        var counter = await _counterRepository.GetCounterById(request.Id);
        if (counter == null) throw new KeyNotFoundException("Counter not found.");

        await _counterRepository.IncrementCounter(request.Id, request.Steps);

        return Unit.Value;
    }
}
