using Application.DTOs.Region;
using Domain.Entities;
using MediatR;

namespace Application.Features.Regions.Requests.Queries;

public class GetRegionRequest : IRequest<RegionDto>
{
    public int Id { get; set; }
}