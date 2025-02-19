using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace StepsLeaderboard.Application.Features.Counters.Handlers;

public class IncrementCounterHandler : IRequestHandler<IncrementCounterCommand, Unit>
{
    private readonly ICounterRepository _counterRepository;

    public IncrementCounterHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    public async Task<Unit> Handle(IncrementCounterCommand request, CancellationToken cancellationToken)
    {
        var counter = await _counterRepository.GetCounterById(request.CounterId);
        if (counter == null) throw new KeyNotFoundException("Counter not found.");

        await _counterRepository.IncrementCounter(request.CounterId, request.Steps);

        return Unit.Value;
    }
}
