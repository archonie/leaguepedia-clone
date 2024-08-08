using Application.Contracts.Persistence.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ICountryRepository : IGenericRepository<Country>
{
    Task<Country> GetCountryWithRegion(int id);
}