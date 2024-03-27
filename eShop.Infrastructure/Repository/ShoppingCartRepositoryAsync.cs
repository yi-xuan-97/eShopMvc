using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository;

public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
{
    public ShoppingCartRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }

    public override async Task<IEnumerable<ShoppingCart>> GetAllAsync()
    {
        // Execute the first asynchronous operation to fetch all shopping carts
        var result =  _context.Set<ShoppingCart>().Include(s => s.CartItems);
        return await result.ToListAsync();

    }

    public async Task<ShoppingCart> GetByCustomerIdAsync(int id)
    {
        // Execute the first asynchronous operation to fetch a shopping cart by customer ID
        var shoppingCart =  _context.Set<ShoppingCart>().Where(x => x.CustomerId == id);

        return await shoppingCart.FirstOrDefaultAsync();
    }
}