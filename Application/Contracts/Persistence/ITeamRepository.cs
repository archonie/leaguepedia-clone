using Application.Contracts.Persistence.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ITeamRepository : IGenericRepository<Team>
{
    Task<Team> GetTeamWithPlayers(int id);
}