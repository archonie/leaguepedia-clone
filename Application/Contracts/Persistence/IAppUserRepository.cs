using Application.Contracts.Persistence.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IAppUserRepository : IGenericRepository<ApplicationUser>
{
    Task<ApplicationUser> FindUserByEmail(string email);
    string GenerateToken(ApplicationUser user);


}