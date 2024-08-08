using Application.Contracts.Persistence;
using Application.Features.Teams.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teams.Handlers.Commands;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
{
    private readonly ITeamRepository _repository;
    private readonly IMapper _mapper;

    public CreateTeamCommandHandler(ITeamRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = _mapper.Map<Team>(request.TeamDto);
        team = await _repository.Add(team);
        return team.Id;
    }
}