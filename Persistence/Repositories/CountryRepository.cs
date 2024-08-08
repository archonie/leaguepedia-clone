using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    private readonly LeagueDbContext _dbContext;

    public CountryRepository(LeagueDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Country> GetCountryWithRegion(int id)
    {
        return await _dbContext.Countries
            .Include(c => c.Leagues)
            .Include(c=>c.NativeTeams)
            .Include(c=> c.OperatingTeams)
            .Include(c=>c.Persons)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}