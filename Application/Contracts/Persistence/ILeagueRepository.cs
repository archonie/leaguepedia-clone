using Application.Contracts.Persistence.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ILeagueRepository : IGenericRepository<League>
{
    Task<League> GetLeagueWithTeams(int id);

}