using Application.Contracts.Persistence;
using Application.DTOs.Team;
using Application.Features.Teams.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Teams.Handlers.Queries;

public class GetTeamRequestHandler : IRequestHandler<GetTeamRequest, TeamDto>
{
    private readonly ITeamRepository _repository;
    private readonly IMapper _mapper;

    public GetTeamRequestHandler(ITeamRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<TeamDto> Handle(GetTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await _repository.GetTeamWithPlayers(request.Id);
        return _mapper.Map<TeamDto>(team);
    }
}