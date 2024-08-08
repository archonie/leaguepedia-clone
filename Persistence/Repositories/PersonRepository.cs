using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    private readonly LeagueDbContext _dbContext;

    public PersonRepository(LeagueDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}