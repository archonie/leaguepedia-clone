using Application.Contracts.Persistence.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IPersonRepository : IGenericRepository<Person>
{
    
}