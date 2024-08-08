namespace Application.Contracts.Persistence.Common;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    
    Task<IEnumerable<T>> Get();
    
    Task<T> Add(T entity);
    
    Task Update(T entity);
    
    Task Delete(T entity);
    
    Task<bool> Exists(int id);
}