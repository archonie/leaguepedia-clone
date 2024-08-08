using Application.DTOs.Region;
using MediatR;

namespace Application.Features.Regions.Requests.Queries;

public class GetRegionListRequest : IRequest<List<RegionListDto>>
{
    
}