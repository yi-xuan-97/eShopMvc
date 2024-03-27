using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;

namespace eShop.Infrastructure.Repository;

public class ProductRepositoryAsync: BaseRepositoryAsync<Product>, IProductRepositoryAsync
{
    public ProductRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }

    // public Product GetByName(string name)
    // {
    //     return _context.Set<Product>().Find(name);
    // }
}