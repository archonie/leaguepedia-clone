using Application.Contracts.Persistence;
using Application.DTOs.League;
using Application.Features.Leagues.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Leagues.Handlers.Queries;

public class GetLeagueRequestHandler : IRequestHandler<GetLeagueRequest, LeagueDto>
{
    private readonly ILeagueRepository _repository;
    private readonly IMapper _mapper;

    public GetLeagueRequestHandler(ILeagueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<LeagueDto> Handle(GetLeagueRequest request, CancellationToken cancellationToken)
    {
        var league = await _repository.GetLeagueWithTeams(request.Id);
        return _mapper.Map<LeagueDto>(league);
    }
}