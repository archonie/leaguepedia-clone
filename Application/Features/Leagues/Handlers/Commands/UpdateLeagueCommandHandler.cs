using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Leagues.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Leagues.Handlers.Commands;

public class UpdateLeagueCommandHandler : IRequestHandler<UpdateLeagueCommand, Unit>
{
    private readonly ILeagueRepository _repository;
    private readonly IMapper _mapper;

    public UpdateLeagueCommandHandler(ILeagueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeagueCommand request, CancellationToken cancellationToken)
    {
        var league = await _repository.Get(request.LeagueDto.Id);
        if (league == null)
        {
            throw new NotFoundException(nameof(League), request.LeagueDto.Id);
        }

        _mapper.Map(request.LeagueDto, league);
        await _repository.Update(league);
        return Unit.Value;
    }
}