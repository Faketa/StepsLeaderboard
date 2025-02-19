namespace StepsLeaderboard.Application.Features.Counters.Handlers;

using MediatR;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Application.Features.Counters.Queries;
using StepsLeaderboard.Application.Features.Counters.DTOs;
using System.Threading;
using System.Threading.Tasks;

public class GetCounterByIdHandler : IRequestHandler<GetCounterByIdQuery, CounterDto>
{
    private readonly ICounterRepository _counterRepository;

    public GetCounterByIdHandler(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    public async Task<CounterDto> Handle(GetCounterByIdQuery request, CancellationToken cancellationToken)
    {
        var counter = await _counterRepository.GetCounterById(request.CounterId);
        if (counter == null) throw new KeyNotFoundException("Counter not found.");

        return new CounterDto(counter.Id, counter.Name, counter.Steps, counter.TeamId);
    }
}
