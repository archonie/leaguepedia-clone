using Application.Contracts.Persistence;
using Application.DTOs.Region;
using Application.Features.Regions.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Regions.Handlers.Queries;

public class GetRegionRequestHandler : IRequestHandler<GetRegionRequest, RegionDto>
{
    private readonly IRegionRepository _repository;
    private readonly IMapper _mapper;

    public GetRegionRequestHandler(IRegionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<RegionDto> Handle(GetRegionRequest request, CancellationToken cancellationToken)
    {
        var region = await _repository.GetRegionWithDetails(request.Id);
        return _mapper.Map<RegionDto>(region);
    }
}