namespace eShop.ApplicationCore.RepositoryInterface;

public interface IRepositoryAsync<T> where T: class
{
    Task<int> InsertAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<int> DeleteAsync(int id);
    Task<int> UpdateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    
}