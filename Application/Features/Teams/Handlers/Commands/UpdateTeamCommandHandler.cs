using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Teams.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teams.Handlers.Commands;

public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, Unit>
{
    private readonly ITeamRepository _repository;
    private readonly IMapper _mapper;

    public UpdateTeamCommandHandler(ITeamRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _repository.Get(request.TeamDto.Id);
        if (team == null)
        {
            throw new NotFoundException(nameof(Team), request.TeamDto.Id);
        }

        
        _mapper.Map(request.TeamDto, team);
        await _repository.Update(team);
        return Unit.Value;
    }
}