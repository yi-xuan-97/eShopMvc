using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository;

public class BaseRepositoryAsync<T>:IRepositoryAsync<T> where T: class
{
    //can only be modify through constructor
    //dependency injection
    protected readonly eShopDbContext _context;
    public BaseRepositoryAsync(eShopDbContext eb)
    {
        _context = eb;
    }
    public async Task<int> InsertAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return  await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(await entity);
            return await _context.SaveChangesAsync();
        }

        return 0;
    }

    public async virtual Task<IEnumerable<T>> GetAllAsync()
    {
        //without ToList() our code will be exucute but will not give us a result
        //delay execution
        //enforce immediate execution 
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id); //where(X=>x.id==id.firstordefault()
    }
}