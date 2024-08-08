using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class LeagueRepostiory : GenericRepository<League>, ILeagueRepository
{
    private readonly LeagueDbContext _dbContext;

    public LeagueRepostiory(LeagueDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<League> GetLeagueWithTeams(int id)
    {
        return await _dbContext.Leauges
            .Include(c => c.Teams)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}