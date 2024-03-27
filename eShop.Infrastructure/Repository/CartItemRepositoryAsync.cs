using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository;

public class CartItemRepositoryAsync: BaseRepositoryAsync<CartItem>, ICartItemRepositoryAsync
{
    public CartItemRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }

    public async Task<IEnumerable<CartItem>> GetbyShoppingCartIdAsync(int id)
    {
        var result = _context.Set<CartItem>().Where(x=> x.ShoppingCartId==id);
        return await result.ToListAsync();
    }

    public async Task<CartItem?> GetByProductIdAsync(int id, int pid)
    {
        var result = _context.Set<CartItem>(); 
        return await result.FirstOrDefaultAsync(x => x.ShoppingCartId == id && x.ProductId == pid);
    }
}