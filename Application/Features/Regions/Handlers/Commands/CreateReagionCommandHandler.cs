using Application.Contracts.Persistence;
using Application.Features.Regions.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Regions.Handlers.Commands;

public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, int>
{
    private readonly IRegionRepository _repository;
    private readonly IMapper _mapper;

    public CreateRegionCommandHandler(IRegionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        var region = _mapper.Map<Region>(request.RegionDto);
        region = await _repository.Add(region);
        return region.Id;
    }
}