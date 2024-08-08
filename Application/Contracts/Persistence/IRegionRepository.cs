using Application.Contracts.Persistence.Common;
using Application.DTOs.Region;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IRegionRepository: IGenericRepository<Region>
{
    Task<Region> GetRegionWithDetails(int id);
}