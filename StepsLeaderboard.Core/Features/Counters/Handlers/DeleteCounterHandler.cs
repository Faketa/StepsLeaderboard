namespace StepsLeaderboard.Application.Features.Counters.Handlers;

using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Commands;
using System.Threading;
using System.Threading.Tasks;

public class DeleteCounterHandler : IRequestHandler<DeleteCounterCommand, Unit>
{
    private readonly ICounterRepository _counterRepository;

    public DeleteCounterHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    public async Task<Unit> Handle(DeleteCounterCommand request, CancellationToken cancellationToken)
    {
        var counter = await _counterRepository.GetCounterById(request.CounterId);
        if (counter == null) throw new KeyNotFoundException("Counter not found.");

        await _counterRepository.DeleteCounter(request.CounterId);

        return Unit.Value;
    }
}
