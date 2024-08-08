using Application.Contracts.Persistence;
using Application.DTOs.League;
using Application.Features.Leagues.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Leagues.Handlers.Queries;

public class GetLeagueListRequestHandler : IRequestHandler<GetLeagueListRequest, List<LeagueListDto>>
{
    private readonly ILeagueRepository _repository;
    private readonly IMapper _mapper;

    public GetLeagueListRequestHandler(ILeagueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<LeagueListDto>> Handle(GetLeagueListRequest request, CancellationToken cancellationToken)
    {
        var leagues = await _repository.Get();
        return _mapper.Map<List<LeagueListDto>>(leagues);
    }
}