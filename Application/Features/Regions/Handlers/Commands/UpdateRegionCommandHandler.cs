using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Regions.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Regions.Handlers.Commands;

public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand, Unit>
{
    private readonly IRegionRepository _repository;
    private readonly IMapper _mapper;

    public UpdateRegionCommandHandler(IRegionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {
        var region = await _repository.Get(request.UpdateRegionDto.Id);
        if (region == null)
        {
            throw new NotFoundException(nameof(Region), request.UpdateRegionDto.Id);
        }

        _mapper.Map(request.UpdateRegionDto, region);
        await _repository.Update(region);
        return Unit.Value;
    }
}