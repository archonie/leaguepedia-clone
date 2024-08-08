using Application.Contracts.Persistence;
using Application.DTOs.League;
using Application.Features.Leagues.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Leagues.Handlers.Commands;

public class CreateLeagueCommandHandler : IRequestHandler<CreateLeagueCommand, int>
{
    private readonly ILeagueRepository _repository;
    private readonly IMapper _mapper;

    public CreateLeagueCommandHandler(ILeagueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeagueCommand request, CancellationToken cancellationToken)
    {
        var league = _mapper.Map<League>(request.LeagueDto);
        league = await _repository.Add(league);
        return league.Id;
    }
}