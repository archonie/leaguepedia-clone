using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    private readonly LeagueDbContext _dbContext;

    public TeamRepository(LeagueDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Team> GetTeamWithPlayers(int id)
    {
        return await _dbContext.Teams
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}