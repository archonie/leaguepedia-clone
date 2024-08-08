using Application.Contracts.Persistence;
using Application.DTOs.Region;
using Application.Features.Regions.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Regions.Handlers.Queries;

public class GetRegionListRequestHandler : IRequestHandler<GetRegionListRequest, List<RegionListDto>>
{
    private readonly IRegionRepository _repository;
    private readonly IMapper _mapper;

    public GetRegionListRequestHandler(IRegionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<RegionListDto>> Handle(GetRegionListRequest request, CancellationToken cancellationToken)
    {
        var regions = await _repository.Get();
        return _mapper.Map<List<RegionListDto>>(regions);
    }
}