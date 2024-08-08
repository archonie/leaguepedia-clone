using Application.Contracts.Persistence;
using Application.DTOs.Region;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class RegionRepository : GenericRepository<Region>, IRegionRepository
{
    private readonly LeagueDbContext _dbContext;

    public RegionRepository(LeagueDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Region> GetRegionWithDetails(int id)
    {
        var region = await _dbContext.Regions
            .Include(r => r.Countries)
            .FirstOrDefaultAsync(r => r.Id == id);
        return region;
    }
}