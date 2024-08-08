using Application.Contracts.Persistence;
using Application.DTOs.Team;
using Application.Features.Teams.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Teams.Handlers.Queries;

public class GetTeamListRequestHandler : IRequestHandler<GetTeamListRequest, List<TeamListDto>>
{
    private readonly ITeamRepository _repository;
    private readonly IMapper _mapper;

    public GetTeamListRequestHandler(ITeamRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<TeamListDto>> Handle(GetTeamListRequest request, CancellationToken cancellationToken)
    {
        var teams = await _repository.Get();
        return _mapper.Map<List<TeamListDto>>(teams);
    }
}