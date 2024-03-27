using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository;

public class CategoryRepositoryAsync: BaseRepositoryAsync<Category>, ICategoryRepositoryAsync
{
    public CategoryRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }

    public override async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Set<Category>().Include( p => p.Products).ToListAsync();
    }
}